using MySqlConnector;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCRM.UI.Authorization
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : TabbedPage
    {
        public Login()
        {
            InitializeComponent();
            logoImage.Source = ImageSource.FromResource("MobileCRM.Resources.Images.crm.jpg");
            qrImage.Source = ImageSource.FromResource("MobileCRM.Resources.Images.consumer.png");
        }

        [Obsolete]
        private void OnWebsiteTapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://mcrm.uz"));
        }

        private void Btn_qr_Clicked(object sender, EventArgs e)
        {

        }

        private void Butt_log_in_Clicked(object sender, EventArgs e)
        {
            //var ipAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            //foreach (var ipAddress in ipAddresses)
            //{
            //    if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        DisplayAlert("ip",ipAddress.ToString(), "ok");
            //    }
            //}

            string User_id = this.text_id.Text;
            string User_login = this.text_login.Text;
            string User_passw = this.text_passw_hide.Text;

            var connection = new MySqlConnection("server = 127.0.0.1; username=root;database=DemoProject;");
            connection.Open();
            string query = "Insert into user(Id, Name, Password) values('1', 'www', 444);";
            var com = new MySqlCommand(query, connection);
            int rowsAffected = com.ExecuteNonQuery();


            //int try_count = 0;

            //try
            //{
            //    if ((User_id != "") && (User_login != "") && (User_passw != ""))
            //    {
            //        string IP = "";
            //        try
            //        {
            //            IP = new WebClient().DownloadString("http://icanhazip.com/");
            //        }
            //        catch (Exception ex)
            //        {
            //            DisplayAlert("Exception", ex.Message, "Ok");
            //        }
            //        IP = IP.Replace("\n", "");

            //        DB db = new DB();

            //        DataTable table1 = new DataTable();

            //        MySqlDataAdapter adapter = new MySqlDataAdapter();

            //        MySqlCommand command1 = new MySqlCommand("SELECT * FROM mcrm_users WHERE id_org = @uD ", db.GetConnection());

            //        command1.Parameters.Add("@uD", MySqlDbType.VarChar).Value = User_id;

            //        adapter.SelectCommand = command1;
            //        adapter.Fill(table1);
            //        if (table1.Rows.Count > 0)
            //        {
            //            DataTable table2 = new DataTable();

            //            MySqlCommand command2 = new MySqlCommand("SELECT * FROM mcrm_users WHERE id_org = @uD AND login = @uL", db.GetConnection());

            //            command2.Parameters.Add("@uD", MySqlDbType.VarChar).Value = User_id;
            //            command2.Parameters.Add("@uL", MySqlDbType.VarChar).Value = User_login;

            //            adapter.SelectCommand = command2;
            //            adapter.Fill(table2);

            //            if (table2.Rows.Count > 0)
            //            {
            //                MySqlDataReader Reader;
            //                db.OpenConnection();
            //                Reader = command2.ExecuteReader();

            //                string user_ip = "";
            //                string user_time = "";

            //                while (Reader.Read())
            //                {
            //                    try_count = Reader.GetInt16("security");
            //                    if (Reader["enter_time"] == DBNull.Value)
            //                        user_time = "";
            //                    else
            //                        user_time = Reader.GetString("enter_time");

            //                    if (Reader["user_ip"] == DBNull.Value)
            //                        user_ip = "";
            //                    else
            //                        user_ip = Reader.GetString("user_ip");
            //                }
            //                db.CloseConnection();

            //                /////////////////////////////////////////////ПРОВЕРЯЕМ ЗАБЛОКИРОВАН ЛИ ПОЛЬЗОВАТЕЛЬ //////////////////////////////////////////////
            //                ///
            //                if ((try_count != 0) && (try_count % 3 == 0) && (IP == user_ip))
            //                {
            //                    //УЗНАЕМ ТОЧНОЕ ВРЕМЯ
            //                    string CheckQuery = "SELECT Now() as CurrentTime";

            //                    MySqlCommand CheckComm = new MySqlCommand(CheckQuery, db.GetConnection());

            //                    MySqlDataReader CheckReader;

            //                    db.OpenConnection();
            //                    CheckReader = CheckComm.ExecuteReader();

            //                    string current_time = "0";

            //                    while (CheckReader.Read())
            //                    {
            //                        current_time = CheckReader.GetString("CurrentTime");
            //                    }
            //                    db.CloseConnection();

            //                    DateTime currtime = DateTime.Parse(current_time);

            //                    current_time = currtime.ToString("HH:mm:ss");
            //                    TimeSpan new_time = TimeSpan.Parse(current_time);


            //                    double minutes = Math.Pow(2, ((try_count / 3) - 1)); ;

            //                    minutes = 1 * minutes;

            //                    TimeSpan time_sp = TimeSpan.FromMinutes(minutes);

            //                    TimeSpan old_time = TimeSpan.Parse(user_time);

            //                    old_time += time_sp;

            //                    /////////////////////////////////////////////ПРОВЕРЯЕМ ПРОШЛО ЛИ ВРЕМЯ БЛОКИРОВКИ//////////////////////////////////////////////
            //                    if (old_time > new_time)
            //                    {
            //                        this.text_support.SetDynamicResource(Span.TextProperty, "supp_locked");

            //                        this.text_support.Text += " на " + minutes + " мин.";

            //                        //--------------------------------------//this.label_error.Text = "Вы заблокированы на " + minutes + " минут";
            //                    }
            //                    else
            //                    {
            //                        this.label_support.IsVisible = false;
            //                        DataTable table3 = new DataTable();

            //                        MySqlCommand command3 = new MySqlCommand("SELECT * FROM mcrm_users WHERE id_org = @uD AND login = @uL AND password = @uP ", db.GetConnection());

            //                        command3.Parameters.Add("@uD", MySqlDbType.VarChar).Value = User_id;
            //                        command3.Parameters.Add("@uL", MySqlDbType.VarChar).Value = User_login;
            //                        command3.Parameters.Add("@uP", MySqlDbType.VarChar).Value = GlobalConstants.CalculateMD5Hash(User_passw);


            //                        adapter.SelectCommand = command3;
            //                        adapter.Fill(table3);

            //                        if (table3.Rows.Count > 0)
            //                        {
            //                            string UpdateQuery = "UPDATE mcrm_users set security= '0' WHERE  id_org = @uD AND login = @uL";

            //                            MySqlCommand UpdateComm = new MySqlCommand(UpdateQuery, db.GetConnection());
            //                            UpdateComm.Parameters.Add("@uD", MySqlDbType.VarChar).Value = User_id;
            //                            UpdateComm.Parameters.Add("@uL", MySqlDbType.VarChar).Value = User_login;

            //                            MySqlDataReader UpdateReader;
            //                            db.OpenConnection();
            //                            UpdateReader = UpdateComm.ExecuteReader();
            //                            db.CloseConnection();

            //                            if (box_remember.IsChecked == true)
            //                            {
            //                                Application.Current.Properties["LoginID"] = User_id;
            //                                Application.Current.Properties["LoginUser"] = User_login;
            //                                Application.Current.Properties["LoginPassword"] = User_passw;
            //                                Application.Current.SavePropertiesAsync();
            //                            }
            //                            else
            //                            {
            //                                Application.Current.Properties["LoginID"] = "";
            //                                Application.Current.Properties["LoginUser"] = "";
            //                                Application.Current.Properties["LoginPassword"] = "";
            //                                Application.Current.SavePropertiesAsync();
            //                            }

            //                            db.OpenConnection();
            //                            MySqlDataReader Reader3;
            //                            Reader3 = command3.ExecuteReader();


            //                            while (Reader3.Read())
            //                            {
            //                                Application.Current.Properties["LoginUser"] = Reader3.GetString("login");
            //                                Application.Current.Properties["UserStatus"] = Reader3.GetString("status");

            //                                Application.Current.Properties["OrgID"] = Reader3.GetString("id_org");
            //                                Application.Current.SavePropertiesAsync();
            //                            }

            //                            db.CloseConnection();
            //                            //--------------------------------------//this.Hide();
            //                            MainPage mainPage = new MainPage();

            //                        }
            //                        else
            //                        {
            //                            /////////////////////////////////////////////ВВЕЛ НЕПРАВИЛЬНЫЙ ПАРОЛЬ //////////////////////////////////////////////
            //                            //ЕСЛИ ПАРОЛЬ НЕПРАВИЛЬНЫЙ ЗАПИСИВАЕМ КОЛ-ВО ПОПЫТОК
            //                            string UpdateQuery = "UPDATE mcrm_users set security=security +'1' WHERE  id_org = @uD AND login = @uL";

            //                            MySqlCommand UpdateComm = new MySqlCommand(UpdateQuery, db.GetConnection());
            //                            UpdateComm.Parameters.Add("@uD", MySqlDbType.VarChar).Value = User_id;
            //                            UpdateComm.Parameters.Add("@uL", MySqlDbType.VarChar).Value = User_login;

            //                            MySqlDataReader UpdateReader;
            //                            db.OpenConnection();
            //                            UpdateReader = UpdateComm.ExecuteReader();
            //                            db.CloseConnection();

            //                            //УЗНАЕМ КОЛ-ВО ПОПЫТОК
            //                            string SelectQuery = "SELECT * FROM mcrm_users WHERE  id_org = @uD AND login = @uL";

            //                            MySqlCommand SelectComm = new MySqlCommand(SelectQuery, db.GetConnection());
            //                            SelectComm.Parameters.Add("@uD", MySqlDbType.VarChar).Value = User_id;
            //                            SelectComm.Parameters.Add("@uL", MySqlDbType.VarChar).Value = User_login;

            //                            MySqlDataReader SelectReader;
            //                            db.OpenConnection();
            //                            SelectReader = SelectComm.ExecuteReader();


            //                            while (SelectReader.Read())
            //                            {
            //                                try_count = SelectReader.GetInt16("security");
            //                            }
            //                            db.CloseConnection();

            //                            ////////////////////////////////////////////////ЕЛСИ ОНО КОЛ-ВО ПОПЫТОК 3 ТОГДА БЛОКИРУЕМ/////////////////////////////////////////////////
            //                            if ((try_count != 0) && (try_count % 3 == 0))
            //                            {
            //                                this.label_support.IsVisible = true;
            //                                this.text_support.SetDynamicResource(Span.TextProperty, "supp_passw_lock");

            //                                //УЗНАЕМ ТОЧНОЕ ВРЕМЯ
            //                                string TimeQuery = "SELECT Now() as CurrentTime";

            //                                MySqlCommand TimeComm = new MySqlCommand(TimeQuery, db.GetConnection());

            //                                MySqlDataReader TimeReader;

            //                                db.OpenConnection();
            //                                TimeReader = TimeComm.ExecuteReader();

            //                                string enter_time = "0";

            //                                while (TimeReader.Read())
            //                                {
            //                                    enter_time = TimeReader.GetString("CurrentTime");
            //                                }
            //                                db.CloseConnection();

            //                                //ЗАПИСИЫВАЕМ ВРЕМЯ БЛОКИРОВКИ
            //                                DateTime datetime = DateTime.Parse(enter_time);

            //                                string date = datetime.ToString("MM/dd/yyyy");
            //                                date = date.Replace("/", "-");
            //                                string time = datetime.ToString("HH:mm:ss");

            //                                string DateQuery = "UPDATE mcrm_users set enter_date = @ued, enter_time = @uet WHERE  id_org = @uD AND login = @uL";

            //                                MySqlCommand DateComm = new MySqlCommand(DateQuery, db.GetConnection());
            //                                DateComm.Parameters.Add("@ued", MySqlDbType.VarChar).Value = date;
            //                                DateComm.Parameters.Add("@uet", MySqlDbType.VarChar).Value = time;
            //                                DateComm.Parameters.Add("@uD", MySqlDbType.VarChar).Value = User_id;
            //                                DateComm.Parameters.Add("@uL", MySqlDbType.VarChar).Value = User_login;

            //                                MySqlDataReader DateReader;
            //                                db.OpenConnection();
            //                                DateReader = DateComm.ExecuteReader();
            //                                db.CloseConnection();
            //                            }
            //                            else
            //                            {
            //                                if ((3 - try_count % 3) == 1)
            //                                {
            //                                    this.label_support.IsVisible = true;
            //                                    this.text_support.SetDynamicResource(Span.TextProperty, "supp_passw_incor1");
            //                                }
            //                                if ((3 - try_count % 3) == 2)
            //                                {
            //                                    this.label_support.IsVisible = true;
            //                                    this.text_support.SetDynamicResource(Span.TextProperty, "supp_passw_incor2");
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    ////////////////////////////////////////////////ЕСЛИ ПОЛЬЗОВАТЕЛЬ НЕ ЗАБЛОКИРОВАН/////////////////////////////////////////////////
            //                    DataTable table3 = new DataTable();

            //                    MySqlCommand command3 = new MySqlCommand("SELECT * FROM mcrm_users WHERE id_org = @uD AND login = @uL AND password = @uP ", db.GetConnection());

            //                    command3.Parameters.Add("@uD", MySqlDbType.VarChar).Value = User_id;
            //                    command3.Parameters.Add("@uL", MySqlDbType.VarChar).Value = User_login;
            //                    command3.Parameters.Add("@uP", MySqlDbType.VarChar).Value = GlobalConstants.CalculateMD5Hash(User_passw);

            //                    adapter.SelectCommand = command3;
            //                    adapter.Fill(table3);

            //                    if (table3.Rows.Count > 0)
            //                    {
            //                        if (this.box_remember.IsChecked == true)
            //                        {
            //                            //Application.Current.Properties["LoginID"] = User_id;
            //                            //Application.Current.Properties["LoginUser"] = User_login;
            //                            //Application.Current.Properties["LoginPassword"] = User_passw;
            //                            //Application.Current.SavePropertiesAsync();
            //                        }
            //                        else
            //                        {
            //                            //Application.Current.Properties["LoginID"] = "";
            //                            //Application.Current.Properties["LoginUser"] = "";
            //                            //Application.Current.Properties["LoginPassword"] = "";
            //                            //Application.Current.SavePropertiesAsync();
            //                        }

            //                        db.OpenConnection();
            //                        MySqlDataReader Reader3;
            //                        Reader3 = command3.ExecuteReader();

            //                        while (Reader3.Read())
            //                        {
            //                            //Application.Current.Properties["LoginUser"] = Reader3.GetString("login");
            //                            //Application.Current.Properties["UserStatus"] = Reader3.GetString("status");
            //                            //Application.Current.Properties["OrgID"] = Reader3.GetString("id_org");
            //                            //Application.Current.SavePropertiesAsync();
            //                        }
            //                        db.CloseConnection();
            //                        //-----------------------------------------------//this.Hide();
            //                        //                                       MainWinParent.Open_MainMenu();
            //                    }
            //                    else
            //                    {
            //                        //ЕСЛИ ПАРОЛЬ НЕПРАВИЛЬНЫЙ ЗАПИСИВАЕМ КОЛ-ВО ПОПЫТОК
            //                        string UpdateQuery, NullQuery;

            //                        if ((try_count != 0) && (IP != user_ip))
            //                        {
            //                            NullQuery = "UPDATE mcrm_users set security='1',user_ip=@uip WHERE  id_org = @uD AND login = @uL";

            //                            MySqlCommand NullComm = new MySqlCommand(NullQuery, db.GetConnection());
            //                            NullComm.Parameters.Add("@uD", MySqlDbType.VarChar).Value = User_id;
            //                            NullComm.Parameters.Add("@uL", MySqlDbType.VarChar).Value = User_login;
            //                            NullComm.Parameters.Add("@uip", MySqlDbType.VarChar).Value = IP;

            //                            MySqlDataReader NullReader;
            //                            db.OpenConnection();
            //                            NullReader = NullComm.ExecuteReader();
            //                            db.CloseConnection();
            //                            try_count++;
            //                        }
            //                        else
            //                        {
            //                            UpdateQuery = "UPDATE mcrm_users set security=security +'1',user_ip=@uip WHERE  id_org = @uD AND login = @uL";

            //                            MySqlCommand UpdateComm = new MySqlCommand(UpdateQuery, db.GetConnection());
            //                            UpdateComm.Parameters.Add("@uD", MySqlDbType.VarChar).Value = User_id;
            //                            UpdateComm.Parameters.Add("@uL", MySqlDbType.VarChar).Value = User_login;
            //                            UpdateComm.Parameters.Add("@uip", MySqlDbType.VarChar).Value = IP;

            //                            MySqlDataReader UpdateReader;
            //                            db.OpenConnection();
            //                            UpdateReader = UpdateComm.ExecuteReader();
            //                            db.CloseConnection();
            //                            try_count++;
            //                        }

            //                        //УЗНАЕМ КОЛ-ВО ПОПЫТОК
            //                        string SelectQuery = "SELECT * FROM mcrm_users WHERE  id_org = @uD AND login = @uL";

            //                        MySqlCommand SelectComm = new MySqlCommand(SelectQuery, db.GetConnection());
            //                        SelectComm.Parameters.Add("@uD", MySqlDbType.VarChar).Value = User_id;
            //                        SelectComm.Parameters.Add("@uL", MySqlDbType.VarChar).Value = User_login;

            //                        MySqlDataReader SelectReader;
            //                        db.OpenConnection();
            //                        SelectReader = SelectComm.ExecuteReader();


            //                        while (SelectReader.Read())
            //                        {
            //                            try_count = SelectReader.GetInt16("security");
            //                        }
            //                        db.CloseConnection();
            //                        this.label_support.IsVisible = true;
            //                        //ЕЛСИ ОНО КОЛ-ВО ПОПЫТОК 3 ТОГДА БЛОКИРУЕМ
            //                        if ((try_count != 0) && (try_count % 3 == 0))
            //                        {
            //                            this.label_support.IsVisible = true;
            //                            this.text_support.SetDynamicResource(Span.TextProperty, "supp_passw_lock");

            //                            //УЗНАЕМ ТОЧНОЕ ВРЕМЯ
            //                            string TimeQuery = "SELECT Now() as CurrentTime";

            //                            MySqlCommand TimeComm = new MySqlCommand(TimeQuery, db.GetConnection());

            //                            MySqlDataReader TimeReader;

            //                            db.OpenConnection();
            //                            TimeReader = TimeComm.ExecuteReader();

            //                            string enter_time = "0";

            //                            while (TimeReader.Read())
            //                            {
            //                                enter_time = TimeReader.GetString("CurrentTime");
            //                            }
            //                            db.CloseConnection();

            //                            //ЗАПИСИЫВАЕМ ВРЕМЯ БЛОКИРОВКИ
            //                            DateTime datetime = DateTime.Parse(enter_time);

            //                            string date = datetime.ToString("MM/dd/yyyy");
            //                            date = date.Replace("/", "-");
            //                            string time = datetime.ToString("HH:mm:ss");

            //                            string DateQuery = "UPDATE mcrm_users set enter_date = @ued, enter_time = @uet, user_ip = @uep  WHERE  id_org = @uD AND login = @uL";

            //                            MySqlCommand DateComm = new MySqlCommand(DateQuery, db.GetConnection());
            //                            DateComm.Parameters.Add("@ued", MySqlDbType.VarChar).Value = date;
            //                            DateComm.Parameters.Add("@uet", MySqlDbType.VarChar).Value = time;
            //                            DateComm.Parameters.Add("@uD", MySqlDbType.VarChar).Value = User_id;
            //                            DateComm.Parameters.Add("@uL", MySqlDbType.VarChar).Value = User_login;
            //                            DateComm.Parameters.Add("@uep", MySqlDbType.VarChar).Value = IP;

            //                            MySqlDataReader DateReader;
            //                            db.OpenConnection();
            //                            DateReader = DateComm.ExecuteReader();
            //                            db.CloseConnection();
            //                        }
            //                        else
            //                        {
            //                            if ((3 - try_count % 3) == 1)
            //                            {
            //                                this.label_support.IsVisible = true;
            //                                this.text_support.SetDynamicResource(Span.TextProperty, "supp_passw_incor1");
            //                            }
            //                            if ((3 - try_count % 3) == 2)
            //                            {
            //                                this.label_support.IsVisible = true;
            //                                this.text_support.SetDynamicResource(Span.TextProperty, "supp_passw_incor2");
            //                            }
            //                        }
            //                    }
            //                }

            //            }
            //            else
            //            {
            //                this.label_support.IsVisible = true;
            //                this.text_support.SetDynamicResource(Span.TextProperty, "supp_login_incorr");
            //            }
            //        }
            //        else
            //        {
            //            this.label_support.IsVisible = true;
            //            this.text_support.SetDynamicResource(Span.TextProperty, "supp_id_incorr");
            //        }
            //    }
            //    else
            //    {
            //        this.label_support.IsVisible = true;
            //        this.text_support.SetDynamicResource(Span.TextProperty, "supp_fill_fields");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    DisplayAlert("Info", ex.Message, "OK");
            //    throw;
            //}
        }
    }
}