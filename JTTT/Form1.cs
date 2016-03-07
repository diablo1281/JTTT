using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using HtmlAgilityPack;
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
            string pass = "Random123";

            Debug.WriteLine("URL: " + url);
            Debug.WriteLine("Word: " + match_word);
            Debug.WriteLine("Mail: " + mail);

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(url);


            //Ustawianie adresów mailowych
            MailAddress from_address = new MailAddress(main_mail, "Nasz piękny program");
            MailAddress to_address = new MailAddress(mail, "Client");
            MailAddress replay_address = new MailAddress(main_mail);

            MailMessage message = new MailMessage(from_address, to_address);
            message.ReplyToList.Add(replay_address);

            //Ustawianie tematu
            message.Subject = "Szukałeś słowa \"" + match_word;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            //Ustawianie treści
            message.Body = html.ToString();
            message.BodyEncoding = System.Text.Encoding.UTF8;

            //Treść w htmlu?
            message.IsBodyHtml = false;

            SendMail(message, main_mail, pass);
        }

        private static void SendMail(MailMessage message, string mail, string pass)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.googlemail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(mail, pass);
            client.Send(message);
        }
    }
}
