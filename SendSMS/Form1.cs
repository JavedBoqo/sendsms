using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace SendSMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var web = new System.Net.WebClient())
            {
                try
                {
                    string userName = "javi_hunzai@hotmail.com";
                    string userPassword = "emxe8";
                    string msgRecepient = "MOBILE-NUMBER";
                    
                    string msgText = "Hello, SMS from MountainShop.pk";
                    string url = "http://smsc.vianett.no/v3/send.ashx?" +
                        "src=" + msgRecepient +
                        "&dst=" + msgRecepient +
                        "&msg=" + System.Web.HttpUtility.UrlEncode(msgText, System.Text.Encoding.GetEncoding("ISO-8859-1")) +
                        "&username=" + System.Web.HttpUtility.UrlEncode(userName) +
                        "&password=" + userPassword;
                    string result = web.DownloadString(url);
                    if (result.Contains("OK"))
                    {
                        MessageBox.Show("Sms sent successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Some issue delivering", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
