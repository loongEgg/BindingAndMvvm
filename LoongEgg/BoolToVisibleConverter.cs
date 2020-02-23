using LoongEgg.Presentation.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoongEgg
{
    public class BoolToVisibleConverter : BaseValueConverter<BoolToVisibleConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (bool)value ? Visibility.Visible : Visibility.Hidden;
    }
}
