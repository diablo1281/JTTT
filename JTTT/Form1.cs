﻿using HtmlAgilityPack;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JTTT
{
    public partial class Form1 : Form
    {
        private CustomLogger logger = new CustomLogger();

        public Form1()
        {
            InitializeComponent();

            //Dodaj do listy pierwszej
            comboBoxIF.Items.Add("Wyszukaj obrazek związany z hasłem");
            comboBoxIF.Items.Add("");

            //Dodaj do listy drugiej
            comboBoxTHEN.Items.Add("Wyślij e-maila z obrazkiem");
            comboBoxTHEN.Items.Add("");

            comboBoxIF.SelectedItem = "Wyszukaj obrazek związany z hasłem";
            comboBoxTHEN.SelectedItem = "Wyślij e-maila z obrazkiem";
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            if (znajdzNaStronie.Visible)
            {
                logger.Write("buttonMake_Click", "Wyszukiwanie obrazków");

                var alts = new List<string>();
                var srcs = new List<string>();

                if (!FindImages(ref alts, ref srcs))
                    return;

                logger.Write("buttonMake_Click", "Wysyłanie emaila");
                if (wyslijMaila.Visible)
                    SendImages(ref alts, ref srcs);
            }

           
        }

        private bool FindImages(ref List<string> alts, ref List<string> srcs)
        {
            string url = znajdzNaStronie.Url;

            if (!url.Contains("http://") && url != "")
                url = "http://" + url;

            if (String.IsNullOrEmpty(znajdzNaStronie.MatchWord))
            {
                var result = MessageBox.Show("Nie podano żadnego słowa kluczowego.\nCzy chcesz wyszukać wszystkie obrazki na stronie?", "Słowo kluczowe", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                logger.Write("FindImages", "Nie podano żadnego słowa kluczowego");

                if (result == DialogResult.No)
                {
                    logger.Write("FindImages", "Anulowane przez użytkownika");
                    Debug.WriteLine("User abort");
                    return false;
                }
            }

            var ok = znajdzNaStronie.FindImages(ref alts, ref srcs, url, znajdzNaStronie.MatchWord);

            if (srcs.Count == 0 && ok)
            {
                MessageBox.Show("Nie znaleziono żadnych obrazków", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Write("FindImages", "Nie znaleziono żadnych obrazków");
                return false;
            }
            else if (!ok)
            {
                logger.Write("FindImages", "Wystąpił błąd w ZnajdzNaStronie.FindImages");
                return false;
            }
           
            MessageBox.Show("Znaleziono " + srcs.Count.ToString() + " obrazków", "Obrazki", MessageBoxButtons.OK, MessageBoxIcon.Information);
            logger.Write("FindImages", "Znaleziono " + srcs.Count + " obrazkó");
            Debug.WriteLine("Site scanned");
            Debug.WriteLine("Picture founds: " + srcs.Count);

            return true;
        }

        private bool SendImages(ref List<string> alts, ref List<string> srcs)
        {
            if (String.IsNullOrEmpty(wyslijMaila.Email))
            {
                logger.Write("SendImages", "Nie podano adresu email");
                MessageBox.Show("Nie podano adresu e-mail", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var message = new MailMessage();
            string subject;

            if (String.IsNullOrEmpty(znajdzNaStronie.MatchWord))
                subject = "Wszystkie obrazki na stronie " + znajdzNaStronie.Url;
            else
                subject = "Hasło \"" + znajdzNaStronie.MatchWord + "\" na stronie " + znajdzNaStronie.Url;

            if (!wyslijMaila.SetAddresses(ref message, wyslijMaila.Email, "Client"))
                return false;

            wyslijMaila.SetSubject(ref message, subject);
            wyslijMaila.AddImagesToBody(ref message, alts, srcs);
            wyslijMaila.SendMail(ref message);

            Debug.WriteLine("Message send to address: " + wyslijMaila.Email);
            logger.Write("SendImages", "Wysłano maila na adres" + wyslijMaila.Email);
            return true;
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
