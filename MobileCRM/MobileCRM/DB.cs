using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MobileCRM
{
    internal class DB
    {
        static public string connString = "Server=83.69.136.27;Database=mcrmbeta;port=3306;User Id=mcrmbeta;password=mcrmbeta;" +
               ";CertificateFile=" + AppDomain.CurrentDomain.BaseDirectory + "images" + @"\" + "Certificate" + @"\" + "main_first.pfx" + ";" +
               "CertificatePassword=jQLv$c9R5(nb!uKCFPgg;" +
               "SslMode=Required";

        //public readonly MySqlConnection connection = new MySqlConnection(connString);

        MySqlConnection connection = new MySqlConnection("server = localhost;username=root;database=mcrmbeta;");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        internal DataTable GetOleDbSchemaTable(Guid tables, object value)
        {
            throw new NotImplementedException();
        }
    }
}
