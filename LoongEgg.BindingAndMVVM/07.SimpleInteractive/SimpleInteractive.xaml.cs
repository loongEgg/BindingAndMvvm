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

namespace LoongEgg.BindingAndMVVM
{
    /// <summary>
    /// SimpleInteractive.xaml 的交互逻辑
    /// </summary>
    public partial class SimpleInteractive : Window
    {
        public SimpleInteractive()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int left = int.Parse(leftText.Text);
            int right = int.Parse(rightText.Text);

            int answer = left + right;

            answerText.Text = answer.ToString();
        }
    }
}
