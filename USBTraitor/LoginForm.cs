using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

namespace USBTraitor
{
    public partial class LoginForm : Form
    {
        
        private OleDbConnection connection = new OleDbConnection();
        public LoginForm()
        {

            InitializeComponent();
            notifyIcon1.Visible = true;
            notifyIcon1.Icon = SystemIcons.Shield;
            notifyIcon1.Text = "USBTraitor is running in the system tray";
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=LoginInfo.accdb;
    Persist Security Info=False;";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from UsernamePassword where Username= '" + textBox1.Text + "' and Password='" + textBox2.Text + "' ";
            OleDbDataReader reader = command.ExecuteReader();

           

            int i = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            while (reader.Read())
            {
                i++;
            }
            if (i >= 1)
            {
                
                connection.Close();
                connection.Dispose();
                this.Hide();

                SelectionForm sf = new SelectionForm();
                sf.Show();                
            }

            else
            {
                MessageBox.Show("Username and Password Incorrect");
            }
            connection.Close();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void LoginForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = SystemIcons.Shield;
               // notifyIcon1.BalloonTipText = "USBTraitor is Running in System tray";
                //notifyIcon1.ShowBalloonTip(1000);
                this.ShowInTaskbar = false;
                
            }

            else if (this.WindowState == FormWindowState.Normal)
            {
                    notifyIcon1.Visible = false;
                    this.Show();
                    notifyIcon1.BalloonTipText = "USBTraitor has come back";
                    this.ShowInTaskbar = true;
                    notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        
   
        
    }
}
