using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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

            //Dodaj do listy pierwszej
            comboBoxIF.Items.Add("Wyszukaj obrazek związany z hasłem");

            //Dodaj do listy drugiej
            comboBoxTHEN.Items.Add("Wyślij e-maila z obrazkiem");

            comboBoxIF.SelectedItem = "Wyszukaj obrazek związany z hasłem";
            comboBoxTHEN.SelectedItem = "Wyślij e-maila z obrazkiem";
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            string url = textBoxURL.Text;
            string match_word = textBoxText.Text;
            string mail = textBoxMail.Text;
            string main_mail = "dotnet.JS.BR@gmail.com";
            string pass = "Random123";

            if (!url.Contains("http://") && url != "")
                url = "http://" + url;

            Debug.WriteLine("URL: " + url);
            Debug.WriteLine("Word: " + match_word);
            Debug.WriteLine("Mail: " + mail);

            //Ustawianie adresów mailowych
            MailAddress from_address = new MailAddress(main_mail, "Nasz piękny program");
            MailAddress to_address = new MailAddress(mail, "Client");
            MailAddress replay_address = new MailAddress(main_mail);

            MailMessage message = new MailMessage(from_address, to_address);
            message.ReplyToList.Add(replay_address);

            AddImageToBody(ref message, url, match_word);

            SendMail(message, main_mail, pass);
        }

        private string GetPageHtml(string url)
        {
            WebClient web_client = new WebClient();
            web_client.Encoding = Encoding.UTF8;
            string html = System.Net.WebUtility.HtmlDecode(web_client.DownloadString(url));
            return html;
        }

        private void AddImageToBody(ref MailMessage message, string url, string match_word)
        {
            //Ustawianie tematu
            message.Subject = "Hasło: \"" + match_word + "\" z witryny " + textBoxURL.Text;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            //Czy treść jest htmlu?
            message.IsBodyHtml = true;

            //Ustawianie treści
            message.Body = "";
            message.BodyEncoding = System.Text.Encoding.UTF8;

            //Wyszukiwanie i wstawianie obrazków w treść maila
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(GetPageHtml(url));
            var nodes = html.DocumentNode.Descendants("img");
            foreach (var node in nodes)
            {
                string url_modify = url;
                string alt = node.GetAttributeValue("alt", "");
                string src = node.GetAttributeValue("src", "");

                url_modify = url_modify.Replace("http://", String.Empty);
                url_modify = url_modify.Replace(".pl", String.Empty);

                if (src.Contains(url_modify) && alt.ToLower().Contains(match_word.ToLower()))
                {
                    message.Body += "<br><b><h3>" + alt + "</h3></b></br>";
                    message.Body += "<br></br><img src=" + src + "><br></br><br></br>";
                    Debug.WriteLine("----ADD----");
                    Debug.WriteLine("alt: " + alt);
                    Debug.WriteLine("src: " + src);
                    Debug.WriteLine("");
                }

            }
        }

        private static void SendMail(MailMessage message, string mail, string pass)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.googlemail.com";
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(mail, pass);
            client.Send(message);
        }

        private void comboBoxIF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxIF.Text == "Wyszukaj obrazek związany z hasłem")
                panelFindPicture.Visible = true;
            else
                panelFindPicture.Visible = false;
        }

        private void comboBoxTHEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTHEN.Text == "Wyślij e-maila z obrazkiem")
                panelSendMail.Visible = true;
            else
                panelSendMail.Visible = false;
        }
    }
}
