using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

/* wechat: InnerGeeker
 * wechat/bilibili: 香辣恐龙蛋
 */

namespace LoongEgg.Presentation.Core
{
    /// <summary>
    /// A base value converter can be used directly in XAML
    /// every value converter should inherit from this
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseValueConverter<T>
        : MarkupExtension, IValueConverter
        where T : class, new()
    {
        /*--------------------------  Private Fields  --------------------------*/ 
        /// <summary>
        /// A single static instance of this value converter
        /// </summary>
        private static T Converter = null; 

        /*--------------------------  Public Methods  --------------------------*/
        /// <summary>
        /// [<see cref="MarkupExtension"/>] Provides a static instance of this value converter 
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
            => Converter ?? (Converter = new T());

        /// <summary>
        /// Converter one type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Convert a value back to it's source type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns> 
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();

    }
}
