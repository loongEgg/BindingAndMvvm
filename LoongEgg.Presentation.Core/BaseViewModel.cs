using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/* wechat: InnerGeeker
 * wechat/bilibili: 香辣恐龙蛋
 */

namespace LoongEgg.Presentation.Core
{

    /// <summary>
    /// The base class of all view model
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event raised when any <see cref="BaseViewModel"/>'s property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise event when property changed 
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Set target to the new value
        /// if the value is different with the old value, raise a property changed event
        /// </summary>
        /// <typeparam name="T">the type of property</typeparam>
        /// <param name="target">the target to set</param>
        /// <param name="value">new value</param>
        /// <param name="propertyName">
        ///     the property name of raise event
        ///     [default auto recognised as <see cref="CallerMemberNameAttribute"/>]
        /// </param>
        /// <returns>ture if set to a new value, and raise a property changed event</returns>
        public bool Set<T>(ref T target, T value, [CallerMemberName]string propertyName = null)
        {
            // 如果value没有变化
            if (EqualityComparer<T>.Default.Equals(target, value))
                return false;

            // 如果确实是一个新的值
            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

    }
}
