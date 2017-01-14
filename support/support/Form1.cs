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

        

        public Form1()
        {
            
            InitializeComponent();

            MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=12345;database=test;";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
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
            MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString);

            //Sample Select Query 
            string strSQL = "SELECT ID, FirstName, LastName FROM YourTable";

            //Open the Connection
            conn.Open();

            //Create MySqlDataAdapter object and assign the query and connection to it
            MySqlDataAdapter mydata = new MySqlDataAdapter(strSQL, conn);

            //Create MySqlCommandBuilder object
            MySqlCommandBuilder cmd = new MySqlCommandBuilder(mydata);

            //Dataset to hold the values
            DataSet ds = new DataSet();

            //Fill the data from MYSQL DB
            mydata.Fill(ds);

            YourGridView.DataSource = ds;
            YourGridView.DataBind();

            //Close the connection
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
