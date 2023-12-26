

using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;
using System;

namespace TaskbarMenu
{
    public class CommandProxy
    {
        public bool OpenMainForm { get; set; } = false;
        public bool OpenSettings { get; set; } = false;
        public bool OpenAbout { get; set; } = false;
        public bool Exit { get; set; } = false;
    }

    public class TaskbarMenu0
    {
        private readonly ResourceDictionary res;
        public TaskbarIcon tbi;
        readonly static public CommandProxy commandProxy = new();

        public TaskbarMenu0()
        {
            res = (ResourceDictionary)Application.LoadComponent(new Uri("/TaskbarMenu;component/TrayIco.xaml", UriKind.Relative));
          //  res.
            tbi = (TaskbarIcon)res["MyNotifyIcon"];
        }
    }
}
