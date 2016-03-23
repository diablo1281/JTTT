using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace JTTT
{
    [Serializable]
    class SendEmail
    {
        private CustomLogger logger = new CustomLogger();

        private string to;
        private string to_name;
        private string subject;
        private string from_name = "Nasz cudowny program";
        private string from = "dotnet.JS.BR@gmail.com";
        private string pass = "Random123";

        private S22.Mail.SerializableMailMessage message;
        
        public string Email
        {
            get
            {
                return to;
            }
        }

        public bool AddressOK { get; set; }

        public SendEmail(string _subject, string _to, string _to_name)
        {
            subject = _subject;
            to = _to;
            to_name = _to_name;

            message = new MailMessage();

            SetSubject();
            AddressOK = SetAddresses();
        }

        public bool SetAddresses()
        {
            var ok = false;
            try
            {
                MailAddress from_address = new MailAddress(from, from_name);
                MailAddress to_address = new MailAddress(to, to_name);

                message.From = from_address;
                message.To.Add(to_address);
                ok = true;
            }
            catch (Exception e)
            {
                logger.Write(e);
                MessageBox.Show("Niepoprawny format adresu email", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine("Exception caught: " + e.ToString());
                ok = false;
            }

            return ok;
        }

        public void SetSubject()
        {
            //Ustawianie tematu
            message.Subject = subject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
        }

        public void AddImagesToBody(List<string> alts, List<string> srcs)
        {
            //Czy treść jest htmlu?
            message.IsBodyHtml = true;

            //Ustawianie treści
            message.Body = "";
            message.BodyEncoding = System.Text.Encoding.UTF8;

            for (int i = 0; i < srcs.Count; i++)
            {
                message.Body += "<br><b><h3>" + alts[i] + "</h3></b></br>";
                message.Body += "<br></br><img src=" + srcs[i] + "><br></br><br></br>";
            }
        }

        public void SendMail()
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.googlemail.com";
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from, pass);
                client.Send(message);
            }
            catch (Exception e)
            {
                logger.Write(e);
                Debug.WriteLine("Error: Couldn't send email");
                MessageBox.Show("Mail nie mógł zostać wysłany.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Mail został wysłany.", "Wysłano", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
