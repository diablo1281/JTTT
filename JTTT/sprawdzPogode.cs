using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JTTT
{
    public partial class sprawdzPogode : UserControl
    {
        public sprawdzPogode()
        {
            InitializeComponent();
        }

        public string City
        {
            get
            {
                return textBoxCity.Text;
            }
            set
            {
                textBoxCity.Text = value;
            }
        }

        public int Temp
        {
            get
            {
                return (int)numericTemp.Value;
            }
            set
            {
                numericTemp.Value = value;
            }
        }
    }
}
