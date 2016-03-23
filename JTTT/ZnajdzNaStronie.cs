using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace JTTT
{
    public partial class ZnajdzNaStronie : UserControl
    {
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
    }
}
