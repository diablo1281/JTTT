﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace JTTT
{
    public partial class ZnajdzNaStronie : UserControl
    {
        private CustomLogger logger = new CustomLogger();

        public string Url
        {
            get
            {
                return textBoxURL.Text;
            }
        }

        public string MatchWord
        {
            get
            {
                return textBoxText.Text;
            }
        }

        public ZnajdzNaStronie()
        {
            InitializeComponent();
        }

        public string GetPageHtml(string url)
        {
            try
            {
                var web_request = WebRequest.Create(url);
                var web_response = web_request.GetResponse();

                Debug.WriteLine("URL is exist");
            }
            catch(WebException e)
            {
                logger.Write(e);
                Debug.WriteLine("Couldn't resolved url: " + e.Message);
                MessageBox.Show("Podana strona nie istnieje", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return String.Empty;
            }
            
            WebClient web_client = new WebClient();
            web_client.Encoding = Encoding.UTF8;
            logger.Write("GetPageHtml", "Załadowano stronę " + url);

            return System.Net.WebUtility.HtmlDecode(web_client.DownloadString(url));
        }

       

        public bool FindImages(ref List<string> alts, ref List<string> srcs, string url, string match_word)
        {
            //Wyszukiwanie obrazów z pasującym opisem
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();

            if(String.IsNullOrEmpty(url))
            {
                logger.Write("FindImages", "Nie podano adresu URL");
                Debug.WriteLine("Missing URL");
                MessageBox.Show("Nie podano adresu URL", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var page_html = GetPageHtml(url);
            if (String.IsNullOrEmpty(page_html))
            {
                logger.Write("FindImages", "Nie załadowano strony");
                return false;
            }
            
            html.LoadHtml(page_html);
            
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
                    Debug.WriteLine("----ADD----");
                    Debug.WriteLine("alt: " + alt);
                    Debug.WriteLine("src: " + src);
                    Debug.WriteLine("");

                    alts.Add(alt);
                    srcs.Add(src);
                }

            }

            return true;
        }
    }
}
