using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;


namespace support
{
    public partial class Form2 : Form
    {
        string myConnectionString = "server=192.168.2.106;uid=rene;" +
                "pwd=rene;database=support;";
       public string combobox;



        public Form2()
        {
           
            


            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO abfrage nach NULL

            if (comboBox1.SelectedItem.ToString() == null)
            {
                MessageBox.Show("Critical Error please restart");
            }
            else
            {
                if (comboBox1.SelectedItem.ToString() == "rene")
                {
                    
                    string text = this.textBox1.Text;
                    string an = this.textBox2.Text;
                    string id = "1";
                    string name = comboBox1.SelectedItem.ToString();


                    MySqlConnection connection = new MySqlConnection(this.myConnectionString);
                    MySqlCommand command = connection.CreateCommand();
                    //command.CommandText = "CREATE TABLE IF NOT EXISTS news (name varchar(100), text varchar(100), an varchar(100), id varchar(100))";
                    string[] textArray2 = new string[] { "INSERT INTO news (name, text, an, id) VALUES ('", name, "','", text, "','", an, "','", id, "')" };
                    command.CommandText = string.Concat(textArray2);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string str7 = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            str7 = str7 + reader.GetValue(i).ToString() + ", ";
                        }
                        Console.WriteLine(str7);
                    }
                    connection.Close();

                }
                else if (comboBox1.SelectedItem.ToString() == "patrik")
                {
                    string text = this.textBox1.Text;
                    string an = this.textBox2.Text;
                    string id = "2";
                    string name = comboBox1.SelectedItem.ToString();


                    MySqlConnection connection = new MySqlConnection(this.myConnectionString);
                    MySqlCommand command = connection.CreateCommand();
                    //command.CommandText = "CREATE TABLE IF NOT EXISTS news (name varchar(100), text varchar(100), an varchar(100), id varchar(100))";
                    string[] textArray2 = new string[] { "INSERT INTO news (name, text, an, id) VALUES ('", name, "','", text, "','", an, "','", id, "')" };
                    command.CommandText = string.Concat(textArray2);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string str7 = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            str7 = str7 + reader.GetValue(i).ToString() + ", ";
                        }
                        Console.WriteLine(str7);
                    }
                    connection.Close();
                }
                else if (comboBox1.SelectedItem.ToString() == "pascal")
                {
                    string text = this.textBox1.Text;
                    string an = this.textBox2.Text;
                    string id = "3";
                    string name = comboBox1.SelectedItem.ToString();


                    MySqlConnection connection = new MySqlConnection(this.myConnectionString);
                    MySqlCommand command = connection.CreateCommand();
                    //command.CommandText = "CREATE TABLE IF NOT EXISTS news (name varchar(100), text varchar(100), an varchar(100), id varchar(100))";
                    string[] textArray2 = new string[] { "INSERT INTO news (name, text, an, id) VALUES ('", name, "','", text, "','", an, "','", id, "')" };
                    command.CommandText = string.Concat(textArray2);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string str7 = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            str7 = str7 + reader.GetValue(i).ToString() + ", ";
                        }
                        Console.WriteLine(str7);
                        connection.Close();
                    }
                    
                }
                else
                {

                    MessageBox.Show("Critical Error please restart");
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.ToString() == "rene") {
                combobox = "rene";
                checknews cn = new checknews();
                cn.check();
            }
            if (comboBox1.Text.ToString() == "patrik")
            {
                combobox = "patrik";
                checknews cn = new checknews();
                cn.check2();
            }
            if (comboBox1.Text.ToString() == "pascal")
            {
                combobox = "pascal";
                checknews cn = new checknews();
                cn.check3();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        private void con()
        {
            Console.WriteLine("HI");
        }
    }
}
