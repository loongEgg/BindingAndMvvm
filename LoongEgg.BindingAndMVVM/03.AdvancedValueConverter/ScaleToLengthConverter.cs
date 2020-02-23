using LoongEgg.Presentation.Core;
using System;
using System.Globalization;

namespace LoongEgg.BindingAndMVVM
{
    /// <summary>
    /// A converter convert the source length with a scale to another length
    /// </summary>
    public class ScaleToLengthConverter : BaseValueConverter<ScaleToLengthConverter>
    {
        /// <summary>
        /// <see cref="ScaleToLengthConverter"/>
        /// </summary>
        /// <param name="value">[double]source length</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">[double] converter parameter</param>
        /// <param name="culture"></param>
        /// <returns>target length</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (double)value * double.Parse(parameter.ToString());
    }
}
