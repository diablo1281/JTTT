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
    public partial class ZnajdzNaStronie : UserControl
    {
        public ZnajdzNaStronie()
        {
            InitializeComponent();
        }

        public string GetPageHtml(string url)
        {
            WebClient web_client = new WebClient();
            web_client.Encoding = Encoding.UTF8;
            string html = System.Net.WebUtility.HtmlDecode(web_client.DownloadString(url));
            return html;
        }

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

        public void FindImages(ref List<string> alts, ref List<string> srcs, string url, string match_word)
        {
            //Wyszukiwanie obrazów z pasującym opisem
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
                    Debug.WriteLine("----ADD----");
                    Debug.WriteLine("alt: " + alt);
                    Debug.WriteLine("src: " + src);
                    Debug.WriteLine("");

                    alts.Add(alt);
                    srcs.Add(src);
                }

            }
        }
    }
}
