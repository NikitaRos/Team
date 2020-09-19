using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multicast
{
    public partial class Form1 : Form
    {
        static string massage = "Hello, word!!!";
        static int interval = 5000;

        Thread sender = new Thread(new ThreadStart(Multicast));

        static void Multicast()
        {
            while(true)
            {
                Thread.Sleep(interval);
                Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                soc.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);

                IPAddress dest = IPAddress.Parse("224.5.5.5");
                soc.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(dest));

                IPEndPoint ipep = new IPEndPoint(dest, 4567);
                soc.Connect(ipep);
                soc.Send(Encoding.Default.GetBytes(massage));
                soc.Close();
            }
        }
        public Form1()
        {
            InitializeComponent();
            sender.IsBackground = true;
            sender.Start();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            massage = richTextBox1.Text;
        }
    }
}
