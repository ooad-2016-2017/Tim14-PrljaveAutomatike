using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TutorFinderApp.Helpers
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> methodToExecute;
        private Predicate<object> canExecuteEvaluator;

        public RelayCommand(Action<object> methodToExecute, Predicate<object> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        public RelayCommand(Action<object> methodToExecute) : this(methodToExecute, null)
        {
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = this.canExecuteEvaluator.Invoke(parameter);
                return result;
            }
        }
        public void Execute(object parameter)
        {
            this.methodToExecute.Invoke(parameter);
        }
    }
}
