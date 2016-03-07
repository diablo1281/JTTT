using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JTTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            string url = textBoxURL.Text;
            string match_word = textBoxText.Text;
            string mail = textBoxMail.Text;
            string main_mail = "dotnet.JS.BR@gmail.com";

            Debug.WriteLine("URL: " + url);
            Debug.WriteLine("Word: " + match_word);
            Debug.WriteLine("Mail: " + mail);

            MailMessage message = new MailMessage(main_mail, mail);
            

        }

        private static void SendMail(MailMessage message, string mail, string pass)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.googlemail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(mail, pass);
            client.Send(message);
        }
    }
}
