using System;
using System.IO;
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

namespace ClientWinForm
{
    public partial class Form1 : Form
    {
        TcpClient client;
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.88.226"), Convert.ToInt32("1024"));

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            client.Connect(endPoint);
            
            var nstream = client.GetStream();
            StreamReader sr = new StreamReader(nstream, Encoding.UTF8);
            
            string s = sr.ReadLine();
            textBoxPred.Text = s;
            
            nstream.Close();
            client.Close();
        }
    }
}
