using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace JTTT
{
    public partial class Form1 : Form
    {
        private CustomLogger logger = new CustomLogger();
        BindingList<IfThenActions> list = new BindingList<IfThenActions>();
        private string file_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\list.dat";

        public Form1()
        {
            InitializeComponent();

            //Dodaj do listy pierwszej
            comboBoxIF.Items.Add("Wyszukaj obrazek związany z hasłem");
            comboBoxIF.Items.Add("Sprawdź temperaturę");
            comboBoxIF.Items.Add("");

            //Dodaj do listy drugiej
            comboBoxTHEN.Items.Add("Wyślij e-mailem");
            comboBoxTHEN.Items.Add("Wyświetl w przeglądarce");
            comboBoxTHEN.Items.Add("");

            comboBoxIF.SelectedItem = "";
            comboBoxTHEN.SelectedItem = "";

            // wczytywanie z bazy danych
            var db = new JTTTDBContext();
            foreach (var el in db.IfThatActions.Include("find").Include("sender").Include("show"))
            {
                this.list.Add(el);
            }
            this.updateList();
        }
        //update listy - wysiwetlanie na ekran
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
                var find = new FindOnWebsite(znajdzNaStronie.Url, znajdzNaStronie.MatchWord);
                var send = new SendEmail(wyslijMaila.Subject, wyslijMaila.Email, "Client");

                var con_act = new IfThenActions(find, send, textBoxName.Text);

                if (!send.AddressOK)
                {
                    logger.Write("buttonMake_Click", "Błąd adresu email");
                    Debug.WriteLine("Error: Email address corrupt");
                    return;
                }
                // 
                list.Add(con_act);

                // dodanie akcji do bazy danych
                var db = new JTTTDBContext();
                db.IfThatActions.Add(con_act);
                db.SaveChanges();

                updateList();
            }
            else if (znajdzNaStronie.Visible && comboBoxTHEN.Text == "Wyświetl obrazki w przeglądarce")
            {
                var find = new FindOnWebsite(znajdzNaStronie.Url, znajdzNaStronie.MatchWord);
                var show = new ShowOnBrowser(find);

                var con_act = new IfThenActions(find, show, textBoxName.Text);

                list.Add(con_act);
                // to samo co wyzej
                var db = new JTTTDBContext();
                db.IfThatActions.Add(con_act);
                db.SaveChanges();

                updateList();
            }
            else if(sprawdzPogode1.Visible && wyslijMaila.Visible)
            {
                var checker = new CheckTemp(sprawdzPogode1.City, sprawdzPogode1.Temp);
                var send = new SendEmail(wyslijMaila.Subject, wyslijMaila.Email, "Client");

                var con_act = new IfThenActions(checker, send, textBoxName.Text);

                if (!send.AddressOK)
                {
                    logger.Write("buttonMake_Click", "Błąd adresu email");
                    Debug.WriteLine("Error: Email address corrupt");
                    return;
                }
                // 
                list.Add(con_act);

                // dodanie akcji do bazy danych
                var db = new JTTTDBContext();
                db.IfThatActions.Add(con_act);
                db.SaveChanges();

                updateList();
            } else if(sprawdzPogode1.Visible && comboBoxTHEN.Text == "Wyświetl obrazki w przeglądarce")
            {
                var checker = new CheckTemp(sprawdzPogode1.City, sprawdzPogode1.Temp);
                var show = new ShowOnBrowser();

                var con_act = new IfThenActions(checker, show, textBoxName.Text);
            }
        }

        private void comboBoxIF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxIF.Text == "Wyszukaj obrazek związany z hasłem")
                znajdzNaStronie.Visible = true;
            else
                znajdzNaStronie.Visible = false;

            if (comboBoxIF.Text == "Sprawdź temperaturę")
                sprawdzPogode1.Visible = true;
            else
                sprawdzPogode1.Visible = false;
        }

        private void comboBoxTHEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTHEN.Text == "Wyślij e-mailem")
                wyslijMaila.Visible = true;
            else
                wyslijMaila.Visible = false;
        }

        private void buttonCleanList_Click(object sender, EventArgs e)
        {

            list.Clear();
            updateList();
            // czyszczenie tabel w bazie dych
            var db = new JTTTDBContext();
            foreach (var el in db.IfThatActions)
            {
                db.IfThatActions.Remove(el);
            }
            foreach (var el in db.fow)
            {
                db.fow.Remove(el);
            }
            foreach (var el in db.sb)
            {
                db.sb.Remove(el);
            }
            foreach (var el in db.sm)
            {
                db.sm.Remove(el);
            }
            db.SaveChanges();
        }

        private void buttonMakeList_Click(object sender, EventArgs e)
        {
            foreach (var item in list)
            {
                item.justDoIt();
            }
        }

        private void buttonSerialize_Click(object sender, EventArgs e)
        {
            if (list.Count == 0)
            {
                logger.Write("buttonDeSerialize_Click", "Nic do serializacji");
                Debug.WriteLine("Error: Nothing to serialize");
                MessageBox.Show("Brak elementów do serializacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (FileStream file = new FileStream(file_path, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter binary_formatter = new BinaryFormatter();
                    binary_formatter.Serialize(file, list);
                }

                logger.Write("buttonDeSerialize_Click", "Serializacja zakończona sukcesem");
                Debug.WriteLine("Error: Serialize success");
                MessageBox.Show("Serializacja zakończona pomyślnie.", "Serialize", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex)
            {
                logger.Write(ex);
                Debug.WriteLine("Error: Couldn't serialize");
                MessageBox.Show("Błąd serializacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeSerialize_Click(object sender, EventArgs e)
        {
            try
            {
                if (list.Count != 0)
                {
                    var answer = MessageBox.Show("Czy chcesz wczytać zapisane dane? \nBierząca zawartość listy zostanie usunięta!", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (answer == DialogResult.No)
                    {
                        logger.Write("buttonDeSerialize_Click", "Przerwane przez użytkownika");
                        Debug.WriteLine("Info: Abort by user");
                        return;
                    }
                }
                using (FileStream file = new FileStream(file_path, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter binary_formatter = new BinaryFormatter();
                    list = (BindingList<IfThenActions>)binary_formatter.Deserialize(file);
                }

                logger.Write("buttonDeSerialize_Click", "Deserializacja zakończona sukcesem");
                Debug.WriteLine("Info: Deserialize success");
                MessageBox.Show("Deserializacja zakończona pomyślnie.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex)
            {
                logger.Write(ex);
                Debug.WriteLine("Error: Couldn't deserialize");
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                updateList();
            }

        }

        private void buttonWeather_MouseClick(object sender, MouseEventArgs e)
        {
            using (var window = new WeatherChecker())
                window.ShowDialog();
        }
    }
}
