using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace JTTT
{
    [Serializable]
    class FindImagesAndSend
    {
        private CustomLogger logger = new CustomLogger();

        private string name;
        private FindOnWebsite find;
        private SendEmail sender;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public override string ToString()
        {
            return name;
        }

        public FindImagesAndSend(FindOnWebsite _find, SendEmail _sender, string _name)
        {
            name = _name;
            find = _find;
            sender = _sender;
        }

        public void justDoIt()
        {
            logger.Write("FindImagesAndSend.justDoIt", "Wyszukiwanie obrazków");
            if (!FindImages())
                return;
            logger.Write("FindImagesAndSend.justDoIt", "Wysyłanie emaila");
            if (!SendImages())
                return;
        }

        public bool FindImages()
        {
            if (!find.Url.Contains("http://") && find.Url != "")
                find.Url = "http://" + find.Url;

            if (String.IsNullOrEmpty(find.MatchWord))
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

            var ok = find.FindImagesOnWebsite();

            if (find.SrcList.Count == 0 && ok)
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

            MessageBox.Show("Znaleziono " + find.SrcList.Count.ToString() + " obrazków", "Obrazki", MessageBoxButtons.OK, MessageBoxIcon.Information);
            logger.Write("FindImages", "Znaleziono " + find.SrcList.Count + " obrazkó");
            Debug.WriteLine("Site scanned");
            Debug.WriteLine("Picture founds: " + find.SrcList.Count);

            return true;
        }

        public bool SendImages()
        {
            sender.AddImagesToBody(find.AltList, find.SrcList);
            sender.SendMail();

            Debug.WriteLine("Message send to address: " + sender.Email);
            logger.Write("SendImages", "Wysłano maila na adres" + sender.Email);
            return true;
        }
    }
}
