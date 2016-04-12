using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    [Serializable]
    public class ShowOnBrowser
    {
        private CustomLogger logger = new CustomLogger();

        [Key]
        public int Id { get; set; }
        public FindOnWebsite find { get; set; }
        public string html_path;
        public string html_body;

        public ShowOnBrowser()
        {

        }

        public ShowOnBrowser(FindOnWebsite _find)
        {
            find = _find;
        }

        public void justDoIt()
        {
            html_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\picture_page.html";
            generateHtml();
            System.Diagnostics.Process.Start(html_path);
        }

        public void justDoIt(string text)
        {
            html_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\picture_page.html";
            generateHtml(text);
            System.Diagnostics.Process.Start(html_path);
        }

        private void generateHtml()
        {
            html_body = "<html><body>";

            for (int i = 0; i < find.SrcList.Count; i++)
            {
                html_body += "\n<br><b><h3>" + find.AltList[i] + "</h3></b></br>";
                html_body += "\n<br></br><img src=" + find.SrcList[i] + "><br></br><br></br>";
            }

            html_body += "</body></html>";

            using (var writer = new StreamWriter(File.Create(html_path)))
            {
                writer.Write(html_body);
            }

        }

        public void generateHtml(string text)
        {
            html_body = "<html><body>";
            html_body += text;
            html_body += "</body></html>";

            html_body.Replace("\n", "</br>");
        }
    }
}
