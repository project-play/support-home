﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace support
{
   public class checknews
    {
        string myConnectionString = "server=127.0.0.1;uid=rene;" +
                "pwd=rene;database=support;";


        public void check()
        {
            
                Form2 f2 = new support.Form2();
                Thread thread = new Thread(new ThreadStart(selectnews));
                thread.Start();
               
            

            
            
        }

        private void selectnews()
        {
          //  Console.WriteLine("1");
            Form2 f2 = new Form2();
            

               
              //  Console.WriteLine("2");
                MySqlConnection connection1 = new MySqlConnection(this.myConnectionString);

                    MySqlCommand command = connection1.CreateCommand();
                    connection1.Open();
                    command.CommandText = "SELECT * FROM news WHERE an='rene'";
                   // Console.WriteLine("3");
                    MySqlDataReader reader = command.ExecuteReader();
                   // Console.WriteLine("4");
                    while (reader.Read())
                    {
                      //  Console.WriteLine("5");
                        string str7 = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            str7 = str7 + reader.GetValue(i).ToString() + ", ";
                        }
                       // Console.WriteLine("6");
                        Console.WriteLine(str7);
                        MessageBox.Show(str7);
                        
                       // Console.WriteLine("7");
                    }
            connection1.Close();
            for (int i = 0; i < 2000; i++)
            {
                Console.WriteLine(i.ToString());
                if (i == 1999)
                {
                    check();
                }
            }
            delete1();


          //  Console.WriteLine("8");
        }
              /*  if (f2.combobox == "patrik")
                {
                    MySqlConnection connection1 = new MySqlConnection(this.myConnectionString);
                    MySqlCommand command = connection1.CreateCommand();
                    connection1.Open();
                    command.CommandText = "SELECT * FROM news WHERE an='patrik'";

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string str7 = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            str7 = str7 + reader.GetValue(i).ToString() + ", ";
                        }
                        Console.WriteLine(str7);
                        MessageBox.Show(str7);
                        connection1.Close();
                    }
                }
                if (f2.combobox == "pascal")
                {
                    MySqlConnection connection1 = new MySqlConnection(this.myConnectionString);
                    MySqlCommand command = connection1.CreateCommand();
                    connection1.Open();
                    command.CommandText = "SELECT * FROM news WHERE an='pascal'";

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string str7 = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            str7 = str7 + reader.GetValue(i).ToString() + ", ";
                        }
                        Console.WriteLine(str7);
                        MessageBox.Show(str7);
                        connection1.Close();
                    }
                }
                */


        public void check2()
        {
            
            
                Form2 f2 = new support.Form2();
                Thread thread = new Thread(new ThreadStart(pat));
                thread.Start();
                
               
            

        }
        public void pat()
        {
            //  Console.WriteLine("1");
            Form2 f2 = new Form2();



            //  Console.WriteLine("2");
            MySqlConnection connection1 = new MySqlConnection(this.myConnectionString);

            MySqlCommand command = connection1.CreateCommand();
            connection1.Open();
            command.CommandText = "SELECT * FROM news WHERE an='patrik'";
            // Console.WriteLine("3");
            MySqlDataReader reader = command.ExecuteReader();
            // Console.WriteLine("4");
            while (reader.Read())
            {
                //  Console.WriteLine("5");
                string str7 = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    str7 = str7 + reader.GetValue(i).ToString() + ", ";
                }
                // Console.WriteLine("6");
                Console.WriteLine(str7);
                MessageBox.Show(str7);
                
                // Console.WriteLine("7");
            }
            connection1.Close();
            for (int i = 0; i < 2000; i++)
            {
                Console.WriteLine(i.ToString());
                if (i == 1999)
                {
                    check2();
                }
            }
            delete2();
        }
        public void check3()
        {
            
                Form2 f2 = new support.Form2();
                Thread thread = new Thread(new ThreadStart(pas));
                thread.Start();
               
            

        }
        public void pas()
        {
            //  Console.WriteLine("1");
            Form2 f2 = new Form2();



            //  Console.WriteLine("2");
            MySqlConnection connection1 = new MySqlConnection(this.myConnectionString);

            MySqlCommand command = connection1.CreateCommand();
            connection1.Open();
            command.CommandText = "SELECT * FROM news WHERE an='pascal'";
            // Console.WriteLine("3");
            MySqlDataReader reader = command.ExecuteReader();
            // Console.WriteLine("4");
            while (reader.Read())
            {
                //  Console.WriteLine("5");
                string str7 = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    str7 = str7 + reader.GetValue(i).ToString() + ", ";
                }
                // Console.WriteLine("6");
                Console.WriteLine(str7);
                MessageBox.Show(str7);
                
                // Console.WriteLine("7");
            }
            connection1.Close();
            for (int i = 0; i < 2000; i++)
            {
                Console.WriteLine(i.ToString());
                if (i == 1999)
                {
                    check3();
                }
            }
            delete3();
        }
        private void delete1()
        {
            MySqlConnection connection1 = new MySqlConnection(this.myConnectionString);

            MySqlCommand command = connection1.CreateCommand();
            connection1.Open();
            command.CommandText ="DELETE FROM news WHERE an='rene'";
            // Console.WriteLine("3");
            MySqlDataReader reader = command.ExecuteReader();
            // Console.WriteLine("4");
            while (reader.Read())
            {
                //  Console.WriteLine("5");
                string str7 = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    str7 = str7 + reader.GetValue(i).ToString() + ", ";
                }
                // Console.WriteLine("6");
                Console.WriteLine(str7);
                

                // Console.WriteLine("7");
            }
        }
        private void delete2()
        {
            MySqlConnection connection1 = new MySqlConnection(this.myConnectionString);

            MySqlCommand command = connection1.CreateCommand();
            connection1.Open();
            command.CommandText = "DELETE FROM news WHERE an='patrik'";
            // Console.WriteLine("3");
            MySqlDataReader reader = command.ExecuteReader();
            // Console.WriteLine("4");
            while (reader.Read())
            {
                //  Console.WriteLine("5");
                string str7 = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    str7 = str7 + reader.GetValue(i).ToString() + ", ";
                }
                // Console.WriteLine("6");
                Console.WriteLine(str7);
                

                // Console.WriteLine("7");
            }
        }
        private void delete3()
        {
            MySqlConnection connection1 = new MySqlConnection(this.myConnectionString);

            MySqlCommand command = connection1.CreateCommand();
            connection1.Open();
            command.CommandText = "DELETE FROM news WHERE an='pascal'";
            // Console.WriteLine("3");
            MySqlDataReader reader = command.ExecuteReader();
            // Console.WriteLine("4");
            while (reader.Read())
            {
                //  Console.WriteLine("5");
                string str7 = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    str7 = str7 + reader.GetValue(i).ToString() + ", ";
                }
                // Console.WriteLine("6");
                Console.WriteLine(str7);
               

                // Console.WriteLine("7");
            }
        }


    }
            
        


    }

