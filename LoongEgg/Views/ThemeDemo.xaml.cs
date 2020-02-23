using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LoongEgg
{
    /// <summary>
    /// ThemeDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ThemeDemo : Window
    {
        public ThemeDemo()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button btn)
            {
                if (btn.Content.ToString()== "DarkTheme")
                {
                    DarkTheme theme = new DarkTheme();
                    this.Resources.MergedDictionaries[0] = theme;
                }
                else
                {
                    LightThemO theme = new LightThemO();
                    this.Resources.MergedDictionaries[0] = theme;
                }
            }
        }
    }
}
