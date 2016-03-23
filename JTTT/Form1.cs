using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace JTTT
{
    public partial class Form1 : Form
    {
        private CustomLogger logger = new CustomLogger();
        BindingList<FindImagesAndSend> list = new BindingList<FindImagesAndSend>();


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

        private void updateList()
        {
            listBox1.DataSource = list;

            listBox1.Refresh();
            listBox1.Update();
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            if (znajdzNaStronie.Visible && wyslijMaila.Visible)
            {
                FindOnWebsite find = new FindOnWebsite(znajdzNaStronie.Url, znajdzNaStronie.MatchWord);
                SendEmail send = new SendEmail(wyslijMaila.Subject, wyslijMaila.Email, "Client");

                FindImagesAndSend con_act = new FindImagesAndSend(find, send, textBoxName.Text);

                list.Add(con_act);
                updateList();
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

        private void buttonCleanList_Click(object sender, EventArgs e)
        {
            list.Clear();
            updateList();
        }

        private void buttonMakeList_Click(object sender, EventArgs e)
        {
            foreach(var item in list)
            {
                item.justDoIt();
            }
        }

        private void buttonSerialize_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonDeSerialize_Click(object sender, EventArgs e)
        {

        }
    }
}
