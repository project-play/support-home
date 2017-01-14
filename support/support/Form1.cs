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

        string myConnectionString = "server=127.0.0.1;uid=rene;" +
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
            Selectmysql("*", "aninfo");
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
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void Selectmysql(string what, string table)
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

                cmd.CommandText = "SELECT * FROM 'aninfo'";
                



            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void insertargs(string table, string arg1, string arg2, string value1, string value2)
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
                string qry = "INSERT INTO " + table + "(" + arg1 + ", " + arg2 + ") VALUES(" + value1 + "," + value2 + ")";
                cmd.CommandText = "INSERT INTO " + table + "(" + arg1 + ", " + arg2 + ") VALUES(" + value1 + "," + value2 + ")";
                Console.Write(qry);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            insertargs("aninfo","names","pw","patrik","vampir11");

        }
    }
}
