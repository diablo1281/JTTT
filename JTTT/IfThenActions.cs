using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows.Forms;

namespace JTTT
{

    [Serializable]
    public class IfThenActions
    {
        public enum Type { FindSend, CheckSend, FindShow, CheckShow }

        private CustomLogger logger = new CustomLogger();

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        // zeby ef mogl sobie wziac i pobrac ten element z bazy danych i zeby go zapisac w bazie danych
        public virtual FindOnWebsite find { get; set; }
        public virtual CheckTemp checker { get; set; }
        public virtual SendEmail sender { get; set; }
        public virtual ShowOnBrowser show { get; set; }
        public Type con_act_type { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public IfThenActions()
        {
            // for EF 
        }

        public IfThenActions(FindOnWebsite _find, SendEmail _sender, string _name)
        {
            Name = _name;
            if (String.IsNullOrEmpty(Name))
                Name = "Find on " + _find.Url + " and send to " + _sender.Email;
            find = _find;
            sender = _sender;
            con_act_type = Type.FindSend;
        }

        public IfThenActions(CheckTemp _checker, SendEmail _sender, string _name)
        {
            Name = _name;
            if (String.IsNullOrEmpty(Name))
                Name = "Is temperature higher than " + _checker.Temp + "? Send it to " + _sender.Email;
            checker = _checker;
            sender = _sender;
            con_act_type = Type.CheckSend;
        }

        public IfThenActions(FindOnWebsite _find, ShowOnBrowser _show, string _name)
        {
            Name = _name;
            if (String.IsNullOrEmpty(Name))
                Name = "Find on " + _find.Url + " and show on browser ";
            find = _find;
            show = _show;
            con_act_type = Type.FindShow;
        }

        public IfThenActions(CheckTemp _checker, ShowOnBrowser _show, string _name)
        {
            Name = _name;
            if (String.IsNullOrEmpty(Name))
                Name = "Is temperature higher than " + _checker.Temp + "? Show me it";
            checker = _checker;
            show = _show;
            con_act_type = Type.CheckShow;
        }

        public void justDoIt()
        {
            switch (con_act_type)
            {
                case Type.FindSend:
                    {
                        logger.Write("IfThenActions.justDoIt", "Wyszukiwanie obrazków");
                        if (!FindImages())
                            return;
                        logger.Write("IfThenActions.justDoIt", "Wysyłanie emaila");
                        if (!SendImages())
                            return;
                    }
                    break;

                case Type.CheckSend:
                    {
                        logger.Write("IfThenActions.justDoIt", "Sprawdzanie temperatury");
                        checker.downloadJson();

                        if(checker.Data.main.temp >= checker.Temp)
                        {
                            sender.AddTextToBody(checker.ToString());
                            sender.SendMail();
                        }
                    }
                    break;

                case Type.FindShow:
                    {
                        logger.Write("IfThenActions.justDoIt", "Wyszukiwanie obrazków");
                        if (!FindImages())
                            return;

                        logger.Write("IfThenActions.justDoIt", "Tworzenie i otwieranie htmla");
                        show.find = find;
                        show.justDoIt();
                    }
                    break;

                case Type.CheckShow:
                    {
                        logger.Write("IfThenActions.justDoIt", "Sprawdzanie temperatury");
                        checker.downloadJson();

                        if (checker.Data.main.temp >= checker.Temp)
                        {
                            show.justDoIt(checker.ToString());
                        }
                    }
                    break;
            }

        }

        public bool FindImages()
        {
            if (String.IsNullOrEmpty(find.MatchWord))
            {
                var result = MessageBox.Show("Nie podano żadnego słowa kluczowego.\nCzy chcesz wyszukać wszystkie obrazki na stronie?", "Słowo kluczowe", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                logger.Write("IfThenActions.FindImages", "Nie podano żadnego słowa kluczowego");

                if (result == DialogResult.No)
                {
                    logger.Write("IfThenActions.FindImages", "Anulowane przez użytkownika");
                    Debug.WriteLine("User abort");
                    return false;
                }
            }

            var ok = find.FindImagesOnWebsite();

            if (find.SrcList.Count == 0 && ok)
            {
                MessageBox.Show("Nie znaleziono żadnych obrazków", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Write("IfThenActions.FindImages", "Nie znaleziono żadnych obrazków");
                return false;
            }
            else if (!ok)
            {
                logger.Write("IfThenActions.FindImages", "Wystąpił błąd w ZnajdzNaStronie.FindImages");
                return false;
            }

            MessageBox.Show("Znaleziono " + find.SrcList.Count.ToString() + " obrazków", "Obrazki", MessageBoxButtons.OK, MessageBoxIcon.Information);
            logger.Write("IfThenActions.FindImages", "Znaleziono " + find.SrcList.Count + " obrazkó");
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
