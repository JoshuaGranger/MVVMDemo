using System;
using System.Windows.Input;

namespace MVVMDemo
{
    public class MyICommand : ICommand
    {
        Action _TargetExecuteMethod;
        //public delegate void _TargetExecuteMethod();
        //public _TargetExecuteMethod _targetExecuteMethod { get; set; }

        Func<bool> _TargetCanExecuteMethod;
        //public delegate bool _TargetCanExecuteMethod();
        //public _TargetCanExecuteMethod _targetCanExecuteMethod { get; set; }

        public MyICommand(Action executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public MyICommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod();
            }
        }
    }
}