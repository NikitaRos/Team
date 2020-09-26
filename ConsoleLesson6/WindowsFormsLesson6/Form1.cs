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
using System.Net.Http;

namespace WindowsFormsLesson6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HttpWebRequest reg = (HttpWebRequest)HttpWebRequest.Create(textBox1.Text);
                reg.Method = "GET";

                //WebProxy proxy = new WebProxy(textBox1.Text);
                //proxy.Credentials = new NetworkCredential(textBox2.Text, textBox3.Text);

                //reg.Proxy = proxy;


                HttpWebResponse res = (HttpWebResponse)reg.GetResponse();

                using (StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.Default))
                {

                        richTextBoxWrite.Text = sr.ReadToEnd();
                }
            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }





        }
    }
}
