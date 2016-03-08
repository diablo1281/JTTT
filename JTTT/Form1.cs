using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
            comboBoxIF.Items.Add("asdasdasdasdasdasdasd");

            //Dodaj do listy drugiej
            comboBoxTHEN.Items.Add("Wyślij e-maila z obrazkiem");
            comboBoxTHEN.Items.Add("Wysda");

            comboBoxIF.SelectedItem = "Wyszukaj obrazek związany z hasłem";
            comboBoxTHEN.SelectedItem = "Wyślij e-maila z obrazkiem";
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            var alts = new List<string>();
            var srcs = new List<string>();

            if (znajdzNaStronie.Visible)
            {
                string url = znajdzNaStronie.Url;
                
                if (!url.Contains("http://") && url != "")
                    url = "http://" + url;

                znajdzNaStronie.FindImages(ref alts, ref srcs, url, znajdzNaStronie.MatchWord);

                Debug.WriteLine("Site scanned");
                Debug.WriteLine("Picture founds: " + srcs.Count);
            }

            if (wyslijMaila.Visible)
            {
                var message = new MailMessage();
                string subject = "Hasło \"" + znajdzNaStronie.MatchWord + "\" na stronie " + znajdzNaStronie.Url;

                wyslijMaila.SetAddresses(ref message, wyslijMaila.Email, "Client");
                wyslijMaila.SetSubject(ref message, subject);
                wyslijMaila.AddImagesToBody(ref message, alts, srcs);
                wyslijMaila.SendMail(ref message);

                Debug.WriteLine("Message send to address: " + wyslijMaila.Email);
            }
        }

        private void comboBoxIF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxIF.Text == "Wyszukaj obrazek związany z hasłem")
                znajdzNaStronie.Visible = true;
            else
                znajdzNaStronie.Visible = false;
        }

        private void comboBoxTHEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTHEN.Text == "Wyślij e-maila z obrazkiem")
                wyslijMaila.Visible = true;
            else
                wyslijMaila.Visible = false;
        }
    }
}
