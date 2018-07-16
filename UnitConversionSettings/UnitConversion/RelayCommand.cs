using System;
using System.Diagnostics;
using System.Windows.Input;

namespace UnitConversionSettings.UnitConversion
{
    public class RelayCommand : ICommand
    {
        readonly Action _execute;
        readonly Predicate<object> _canExecute;

        public RelayCommand(Action execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameters)
        {
            return _canExecute?.Invoke(parameters) ?? true;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameters)
        {
            _execute();
        }
    }
}