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



namespace Client
{
    public partial class Form1 : Form
    {
        static private Socket Client;
        private IPAddress ip = null;
        private int port = 0;


        public Form1()
        {
            InitializeComponent();

            richTextBox1.Enabled = false;
            richTextBox2.Enabled = false;
            button1.Enabled = false;

            try
            {
                var sr = new StreamReader(@"Client_info/data_info.txt");
                string buffer = sr.ReadToEnd();
                sr.Close();
                string[] connect_info = buffer.Split(':');
                ip = IPAddress.Parse(connect_info[0]);
                port = int.Parse(connect_info[1]);


                


            }
            catch (Exception ex)
            {
                Form2 form = new Form2();
                form.Show();


            }



        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
        void RevoMessage()
        {
            byte[] buffer = new byte[1024];
            for(int i= 0; i < buffer.Length ; i++)
            {
                buffer[i] = 0;

            }
            //Тут остановился
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != " " && textBox1.Text != "" && textBox1.Text != " ")
            {
                button1.Enabled = true;
                richTextBox2.Enabled = true;
                Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

               if(ip != null)
                {

                    Client.Connect(ip, port); 

                }

               
            }

               

            
        }
    }
}
