using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;

namespace USBTraitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
           
            OleDbConnection connection = new OleDbConnection();
            string userName=null, password=null;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=LoginInfo.accdb;
    Persist Security Info=False;";
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;


            
            string formatAdd = "SELECT * FROM UsernamePassword";
            command.CommandText = formatAdd;

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                userName = (reader["Username"].ToString());
                password = (reader["Password"].ToString());
            }

            connection.Close();
            if (userName != null && password != null)
            {
                Application.Run(new LoginForm()); 
            }
            else
                Application.Run(new SetPassword());
        }
    }
}
