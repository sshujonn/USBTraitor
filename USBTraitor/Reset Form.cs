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
    public partial class Reset_Form : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Reset_Form()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=LoginInfo.accdb;
    Persist Security Info=False;";
        }

        private void Reset_Form_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from UsernamePassword where Username= '" + textBox1.Text + "' and Password='" + textBox2.Text + "' ";
                OleDbDataReader reader = command.ExecuteReader();



                int i = 0;
                //textBox1.Text = "";
                //textBox2.Text = "";
                while (reader.Read())
                {
                    i++;
                }
                connection.Close();
                if (i >= 1)
                {
                    connection.Open();
                    //OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string delete = "DELETE FROM UsernamePassword where Username= '" + textBox1.Text + "' and [Password]='" + textBox2.Text + "' ";
                    command.CommandText = delete;
                    command.ExecuteNonQuery();
                    connection.Close();

                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        connection.Open();
                        //OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        string addUP = "insert into UsernamePassword(Username,[Password]) values ('" + textBox3.Text + "','" + textBox4.Text + "')";
                        command.CommandText = addUP;
                        command.ExecuteNonQuery();
                        connection.Close();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        MessageBox.Show("Successfully Changed");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Please Fill all the boxes");
                }

                else
                    MessageBox.Show("Please enter a valid username and password");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong:::"+ex.Source);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = button2;
        }
    }
}
