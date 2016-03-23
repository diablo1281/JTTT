using System.Windows.Forms;

namespace JTTT
{
    public partial class WyslijMaila : UserControl
    {
        public WyslijMaila()
        {
            InitializeComponent();
        }

        public string Email
        {
            get
            {
                return textBoxMail.Text;
            }
        }

        public string Subject
        {
            get
            {
                return textBoxSubject.Text;
            }
        }
    }
}
