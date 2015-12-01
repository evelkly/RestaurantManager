﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Composition;
using Windows.UI.Notifications;

namespace RestaurantManager.Extensions
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Func<T, bool> _canExecuteMethod;
        private readonly Action<T> _executeMethod;

        public DelegateCommand(Action<T> executeMethod) : this(executeMethod , null)
        {
            
        }

        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged;

        bool ICommand.CanExecute(object parameter)
        {
            try
            {
                return CanExecute((T) parameter);
            }
            catch
            {
                return false;
            }
        }

        void ICommand.Execute(object parameter)
        {
            Execute((T) parameter);
        }

        public bool CanExecute(T parameter)
        {
            return ((_canExecuteMethod == null) || _canExecuteMethod(parameter));
        }

        public void Execute(T parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod(parameter);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, e);
        }
    }
}
