using LoongEgg.Presentation.Core;
using System;
using System.Globalization;
using System.Windows.Media;

namespace LoongEgg.Presentation.Demo
{
    /// <summary>
    /// 将单一的A、R、B分量转换为<see cref="Color"/>
    /// </summary>
    public class ComponentToColorConverter : BaseValueConverter<ComponentToColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter.ToString().ToUpper())
            {
                case "R": return Color.FromRgb((byte)value, 0, 0);
                case "G": return Color.FromRgb(0, (byte)value, 0);
                case "B": return Color.FromRgb(0, 0, (byte)value);
                default:
                    throw new Exception("UnKnown color component"); 
            }
        }
    }
}
