using System;
using System.Windows;

namespace LoongEgg.BindingAndMVVM
{
    /// <summary>
    /// UsingBaseViewModel.xaml 的交互逻辑
    /// </summary>
    public partial class UsingBaseViewModel : Window
    {
        public UsingBaseViewModel()
        {
            InitializeComponent();
            //DataContext = new MathViewModel();
        }
         
        [Obsolete("不推荐使用")]
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int left = int.Parse(leftText.Text);
            int right = int.Parse(rightText.Text);

            int answer = left + right;

            answerText.Text = answer.ToString();
        }
    }
}
