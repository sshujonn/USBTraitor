using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Speech;
using System.Speech.Synthesis;
using System.Media;
using System.Data.OleDb;

namespace USBTraitor
{
    public partial class SetPassword : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public SetPassword()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=LoginInfo.accdb;
    Persist Security Info=False;";
            InitializeComponent();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void SetPassword_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
                 if(textBox2.Text==textBox3.Text && textBox1.Text!="" && textBox2.Text!="")
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string addUP = "insert into UsernamePassword(Username,[Password]) values ('" + textBox1.Text + "','" + textBox2.Text + "')";
                    command.CommandText = addUP;
                    command.ExecuteNonQuery();
                    connection.Close();

                    if (checkBox1.Checked == true)
                    {
                        copyFile();
                    }
                    this.Hide();
                    SelectionForm sf = new SelectionForm();
                    sf.Show();
                    
                }

                 else if (textBox2.Text != textBox3.Text)
                 {
                     MessageBox.Show("Password doesn't match");
                 }
                 else
                 {
                     MessageBox.Show("Enter Username & Password");
                 }
                
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }

        void copyFile()
        {
            string[] files = Directory.GetFiles(@Application.StartupPath, "*.lnk");
            foreach (string file in files)
            {
                File.Copy(file, Path.Combine(@Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\", Path.GetFileName(file)), true);
            }
        }
    }
}
