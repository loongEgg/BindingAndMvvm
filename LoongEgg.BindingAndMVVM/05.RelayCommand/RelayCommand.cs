using System;
using System.Windows.Input;

namespace LoongEgg.BindingAndMVVM
{
    /// <summary>
    /// The base command run an action
    /// </summary>
    public class RelayCommand : ICommand
    {
        /*-------------------------  Public Property  -------------------------*/
        /// <summary>
        /// The event raised when <see cref="CanExecute(object)"/> changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (s, e) => { };

        /*---------------------------  Constructor  ---------------------------*/
        /// <summary>
        /// Constructor of <see cref="RelayCommand"/>
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        /*--------------------------  Public Methods  --------------------------*/
        /// <summary>
        /// Check if this command action can execute
        /// NOTE: If can execute function not set, will always return true;
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns> 
        public bool CanExecute(object parameter)
            => _CanExecute == null ? true : _CanExecute(parameter);
        private readonly Func<object, bool> _CanExecute = null;

        /// <summary>
        /// The action to execute this command
        /// </summary>
        /// <param name="parameter"></param> 
        public void Execute(object parameter)
            => _Execute(parameter);
        private readonly Action<object> _Execute;
    }
}
