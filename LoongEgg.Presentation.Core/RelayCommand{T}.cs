
using System;
using System.Windows.Input;

/* wechat: InnerGeeker
 * wechat/bilibili: 香辣恐龙蛋
 */

namespace LoongEgg.Presentation.Core
{
    /// <summary>
    /// The base command run an action
    /// </summary>
    public class RelayCommand<T> : ICommand
    {
        /*-------------------------  Public Property  -------------------------*/

        /*---------------------------  Constructor  ---------------------------*/
        /// <summary>
        /// Constructor of <see cref="RelayCommand"/>
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        /*--------------------------  Public Methods  --------------------------*/
        /// <summary>
        /// The action to execute this command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
            => _Execute((T)parameter);
        private readonly Action<T> _Execute;

        /// <summary>
        /// Check if this command action can execute
        /// NOTE: If the can execute function not set, will always return true;
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
            => _CanExecute == null ? true : _CanExecute((T)parameter);
        private readonly Func<T, bool> _CanExecute = null;
         
        /// <summary>
        /// The event raised when <see cref="CanExecute(object)"/> changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (s, e) => { };

    }
}
 
