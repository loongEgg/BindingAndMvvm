using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace LoongEgg
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.UtcNow >= new DateTime(2021,2,14))
            {
                MessageBox.Show("预览版到期，请下载依然免费的正式版");
                return;
            }
            // Get the current button.
            Button cmd = (Button)e.OriginalSource;

            // Create an instance of the window named
            // by the current button.
            Type type = this.GetType();
            Assembly assembly = type.Assembly;
            Window win = (Window)assembly.CreateInstance(
                type.Namespace + "." + cmd.Content); //Namespace.ClassName

            // Show the window.
            win.Show();
            this.Close();
        }
    }
}
