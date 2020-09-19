using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NetProgTCPIP
{
    class Program
    {
        static readonly TcpListener listerin = new TcpListener(IPAddress.Parse("192.168.88.226"), Convert.ToInt32("1024"));
        
        static void Main(string[] args)
        {
            var thread = new Thread(SomeAction);
            thread.Start();
            listerin.Start();
        }

        private static void SomeAction()
        {
            string filename = "Predictions.txt";
            int a;
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            while (true)
            {
                if (listerin.Pending())
                {
                    var client = listerin.AcceptTcpClient();
                    var nstream = client.GetStream();

                    string[] line = File.ReadAllLines(filename);
                    a = rand.Next(1, line.Length);

                    byte[] barray = Encoding.UTF8.GetBytes(line[a]);
                    nstream.Write(barray, 0, barray.Length);
                       
                    nstream.Close();
                    client.Close();
                }
            }
        }
    }
}
