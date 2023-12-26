using System;
using System.Windows.Input;

namespace TaskbarMenu
{
    public class OpenCommand : ICommand
    {

        public void Execute(object? parameter)
        {
            TaskbarMenu.TaskbarMenu0.commandProxy.OpenMainForm = true;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public event EventHandler? CanExecuteChanged;
    }

    public class SettingsCommand : ICommand
    {
        public void Execute(object? parameter)
        {
            TaskbarMenu.TaskbarMenu0.commandProxy.OpenSettings = true;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public event EventHandler? CanExecuteChanged;
    }

    public class AboutCommand : ICommand
    {

        public void Execute(object? parameter)
        {
            TaskbarMenu.TaskbarMenu0.commandProxy.OpenAbout = true;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public event EventHandler? CanExecuteChanged;
    }

    public class ExitCommand : ICommand
    {

        public void Execute(object? parameter)
        {
            TaskbarMenu.TaskbarMenu0.commandProxy.Exit = true;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public event EventHandler? CanExecuteChanged;
    }
}
