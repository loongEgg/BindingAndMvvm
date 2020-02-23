using System;
using System.Globalization;
using System.Windows.Data;

/* wechat: InnerGeeker
 * wechat/bilibili: 香辣恐龙蛋
 */

namespace LoongEgg.BindingAndMVVM
{
    /// <summary>
    /// Convert a sacle and a source length into another target length
    /// </summary>
    class ScaleConverter : IValueConverter
    {
        /// <summary>
        /// <see cref="ScaleConverter"/>
        /// </summary>
        /// <param name="value">[<see cref="double"/>] source length</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">[<see cref="double"/>] traget length</param>
        /// <param name="culture"></param>
        /// <returns>[<see cref="double"/>] target length</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double height = (double)value;
            if (double.TryParse(parameter.ToString(), out double scale))
            {
                return height * scale;
            }
            else
            {
                throw new Exception($"parameter convert error:{parameter}");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
          => throw new NotImplementedException();
    }
}
