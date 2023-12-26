using System.Net;
using System.Transactions;
using System.Windows;
using System.Windows.Controls.Primitives;
using static PIRIHashesGenerator.PIRIHashesGenerator;

namespace PIRIHashesGenerator.units
{
    public class Notifications
    {
        static PIRIHashesGenerator? PH;
        static bool opened = false;
        readonly TaskbarPopup.TaskbarPopup0 uc;
        static ProxyControl? proxyControl;

        public Notifications(PIRIHashesGenerator in_)
        {
            PH = in_;
            uc = new(SetClose);
            proxyControl = new(uc);
        }
        public static bool SetClose()
        {
            opened = false;

            proxyControl?.Hide();

            // PH?.tray.tbm.tbi.CloseBalloon();
            return true;
        }

        //public void RunDebug()
        //{
        //    if (PH != null)
        //    {
        //        if ((PH.SnS.UserSettings["taskbarNotification"] != "+") || (PH.SnS.UserSettings["taskbarIncome"] != "+"))
        //        {
        //            return;
        //        }
        //        if (opened) return;
        //        TaskbarPopup.TransactionRecord TR = new(
        //        "",
        //        "",
        //        "",
        //        "",
        //            "",
        //            "");

        //        uc.TaskbarPopup1_Update(TR);
        //        uc.Visibility = Visibility.Visible;

        //        PH.tray.tbm.tbi.ShowCustomBalloon(uc, PopupAnimation.Slide, 60 * 1000 * 60 * 24);
        //        try
        //        {
        //            Audio.PlaySound(int.Parse(PH.SnS.UserSettings["incomeSoundIndex"]) + 1, int.Parse(PH.SnS.UserSettings["incomeSoundLevel"]));
        //        }
        //        catch (Exception) { }

        //        opened = true;
        //    }
        //}
        //public void RunNotifications0( TransactionRecord transaction)
        //{

        //    if (PH != null)
        //    {
        //        if ((PH.SnS.UserSettings["taskbarNotification"] != "+") || (PH.SnS.UserSettings["taskbarIncome"] != "+"))
        //        {
        //            return;
        //        }
        //        if (opened) return;
        //        TaskbarPopup.TransactionRecord TR = new(
        //            transaction.Type,
        //            transaction.TransactionHash,
        //            transaction.From,
        //            transaction.To,
        //            transaction.Amount,
        //            transaction.Direction);

        //        uc.TaskbarPopup1_Update(TR);
        //        uc.Visibility = Visibility.Visible;

        //        PH.tray.tbm.tbi.ShowCustomBalloon(uc, PopupAnimation.Slide, 60 * 1000 * 60 * 24);
        //        try
        //        {
        //            Audio.PlaySound(int.Parse(PH.SnS.UserSettings["incomeSoundIndex"]) + 1, int.Parse(PH.SnS.UserSettings["incomeSoundLevel"]));
        //        }
        //        catch (Exception) { }

        //        opened = true;
        //    }
        //}

        public void RunNotifications(TransactionRecord transaction)
        {

            if (PH != null)
            {
                if ((PH.SnS.UserSettings["taskbarNotification"] != "+") || (PH.SnS.UserSettings["taskbarIncome"] != "+"))
                {
                    return;
                }
                if (opened) return;

                TaskbarPopup.TransactionRecord TR = new(
                    transaction.Type,
                    transaction.TransactionHash,
                    transaction.From,
                    transaction.To,
                    transaction.Amount,
                    transaction.Direction);


                uc.TaskbarPopup1_Update(TR);
                uc.Visibility = Visibility.Visible;

                proxyControl?.RunPopup();

                //  PH.tray.tbm.tbi.ShowCustomBalloon(uc, PopupAnimation.Slide, 60 * 1000 * 60 * 24);


                try
                {
                    Audio.PlaySound(int.Parse(PH.SnS.UserSettings["incomeSoundIndex"]) + 1, int.Parse(PH.SnS.UserSettings["incomeSoundLevel"]));
                }
                catch (Exception) { }

                opened = true;
            }
        }

        public void RunDebug()
        {

            if (PH != null)
            {
                if ((PH.SnS.UserSettings["taskbarNotification"] != "+") || (PH.SnS.UserSettings["taskbarIncome"] != "+"))
                {
                    return;
                }
                if (opened) return;

                TaskbarPopup.TransactionRecord TR = new(
                "",
                "",
                "",
                "",
                    "",
                    "");


                uc.TaskbarPopup1_Update(TR);
                uc.Visibility = Visibility.Visible;

                proxyControl?.RunPopup();
                //  PH.tray.tbm.tbi.ShowCustomBalloon(uc, PopupAnimation.Slide, 60 * 1000 * 60 * 24);


                try
                {
                    Audio.PlaySound(int.Parse(PH.SnS.UserSettings["incomeSoundIndex"]) + 1, int.Parse(PH.SnS.UserSettings["incomeSoundLevel"]));
                }
                catch (Exception) { }

                opened = true;
            }

        }
    }
}
