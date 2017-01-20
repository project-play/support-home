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


namespace support
{
    public partial class Form1 : Form
    {

        string myConnectionString = "server=192.168.2.106;uid=rene;" +
                "pwd=rene;database=support;";



        public Form1()
        {

            InitializeComponent();

            MySqlConnection conn;


            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Selectmysql("*", "aninfo", "id", "1");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        public void createtable(string table, string arg1, string arg2)
        {
            MySqlConnection conn;
            MySqlCommand cmd;

            conn = new MySqlConnection();
            cmd = new MySqlCommand();

            conn.ConnectionString = myConnectionString;

            try
            {
                conn.Open();
                cmd.Connection = conn;
                string qry = "CREATE TABLE `support`.`anmeldeinfos` ( `names` VARCHAR(100) NOT NULL, `pw` VARCHAR(100) NOT NULL ) ENGINE = InnoDB";
                cmd.CommandText = "CREATE TABLE `support`.`anmeldeinfos` ( `names` VARCHAR(100) NOT NULL, `pw` VARCHAR(100) NOT NULL ) ENGINE = InnoDB";


                Console.Write(qry);
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void Selectmysql(string what, string table, string where, string arg)
        {
            // TODO: fix that nobody can login with null
            
            MySqlConnection connection1 = new MySqlConnection(this.myConnectionString);
            MySqlCommand command = connection1.CreateCommand();
            connection1.Open();
            command.CommandText = "SELECT " + what + " FROM " + table + " WHERE " + where + "='" + arg + "'";
            bool flag = false;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string str3 = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    str3 = str3 + reader.GetValue(i).ToString() + ", ";
                }
                Console.WriteLine(str3);
                
                if (str3.Contains(this.textBox1.Text) && textBox1.Text != null)
                {
                    if (str3.Contains(this.textBox2.Text) && textBox2.Text != null)
                    {
                        flag = false;
                        base.Hide();
                        new Form2().ShowDialog();
                        connection1.Close();
                        return;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = true;
                }
            }
            if (flag)
            {
                flag = false;
                MessageBox.Show("Fehler beim Anmelden bitte \x00fcberpr\x00fcfe deine Login daten\noder deine Internetverbindung ansonste kontaktiere Ren\x00e9");
                connection1.Close();
            }
            connection1.Close();
        }




        private void insertargs(string table, string arg1, string arg2, string arg3, string value1, string value2, string value3)
        {

            MySqlConnection connection1 = new MySqlConnection(this.myConnectionString);
            MySqlCommand command = connection1.CreateCommand();
            connection1.Open();
            string qry = "INSERT INTO " + table + " (" + arg1 + ", " + arg2 + ", " + arg3 + ") VALUES('" + value1 + "', '" + value2 + "', '" + value3 + "')";
                command.CommandText = "INSERT INTO " + table + " (" + arg1 + ", " + arg2 + ", " + arg3 + ") VALUES('" + value1 + "', '" + value2 + "', '" + value3 + "')";
                Console.Write(qry);
            connection1.Close();
            }
           

        private void button2_Click_1(object sender, EventArgs e)
        {
            insertargs("aninfo", "names", "pw", "id", textBox1.Text, textBox2.Text, "1");
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
