using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Net;
using System.Net.Sockets;
using System.IO;

namespace support_chat
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public String text_to_send;

        public Form1()
        {

            




            InitializeComponent();
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());   // Eigene IP herausbekommne
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox3.Text = address.ToString();
                }
            }





        }

        private void button2_Click(object sender, EventArgs e) // starte den server dürfen nur admins
             
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(textBox6.Text));
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;
            backgroundWorker1.RunWorkerAsync();                   // starte bekommen der Daten im Hintergrund
            backgroundWorker2.WorkerSupportsCancellation = true; // Kann den thread abbrechen


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) // Bekomme Daten
        {
            while (client.Connected)
            {
                try
                {
                    receive = STR.ReadLine();
                    this.textBox2.Invoke(new MethodInvoker(delegate() { textBox2.AppendText("Einer von uns : " + receive + "\n"); }));

                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e) // Sende daten
        {
            if (client.Connected)
            {
                STW.WriteLine(text_to_send);
                this.textBox2.Invoke(new MethodInvoker(delegate() { textBox2.AppendText("ME : " + text_to_send + "\n"); }));

            }
            else
            {
                MessageBox.Show("Fehler beim Senden bitte kontaktire den Admin des Systems");
            }
            backgroundWorker2.CancelAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse(textBox4.Text), int.Parse(textBox5.Text.ToString()));

            try
            {
                client.Connect(IP_End);
                if (client.Connected)
                {
                    textBox2.AppendText("Zum Server verbunden" + "\n");
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;

                    backgroundWorker1.RunWorkerAsync();                   // starte bekommen der Daten im Hintergrund
                    backgroundWorker2.WorkerSupportsCancellation = true; // Kann den thread abbrechen
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e) // senden knopf
        {
            if (textBox1.Text != "")
            {
                text_to_send = textBox1.Text;
                backgroundWorker2.RunWorkerAsync();

            }
            textBox1.Text = "";

        }
    }
}
