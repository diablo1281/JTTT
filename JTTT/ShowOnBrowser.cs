using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    [Serializable]
    class ShowOnBrowser
    {
        private CustomLogger logger = new CustomLogger();
        public FindOnWebsite find { get; set; }
        private string html_path;
        private string html_body;

        public ShowOnBrowser(FindOnWebsite _find)
        {
            find = _find;
            html_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\picture_page.html";
        }

        public void justDoIt()
        {
            generateHtml();
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
    }
}
