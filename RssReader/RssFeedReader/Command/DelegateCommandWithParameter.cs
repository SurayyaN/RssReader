using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RssFeedReader.Command
{
    class DelegateCommandWithParameter<T> : ICommand
    {
        private readonly Action<T> _action;

        public DelegateCommandWithParameter(Action<T> action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action((T)Convert.ChangeType(parameter, typeof(T)));
        }

        public bool CanExecute(object Parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
