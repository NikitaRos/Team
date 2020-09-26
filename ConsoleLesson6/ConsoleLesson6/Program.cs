using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;
using System.IO;

namespace ConsoleLesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest rq = (HttpWebRequest)HttpWebRequest.Create("http://itstep.org");

            rq.Headers.Add("Accept-Language: ru-ru.");

            HttpWebResponse rs = (HttpWebResponse)rq.GetResponse();

            using (StreamReader sr = new StreamReader(rs.GetResponseStream(), Encoding.Default))
            {
                foreach (string head in rs.Headers)
                {
                    Console.WriteLine("{0}+{1}", head, rs.Headers[head]);
                }
            }

            Console.WriteLine();
            WebClient client = new WebClient();
            byte[] urlData = client.DownloadData("http://itstep.org");
            string page = Encoding.Default.GetString(urlData);
            Console.WriteLine(page);
        }
    }
}
