using LoongEgg.Presentation.Core;
using System.Windows;
using System.Windows.Input;

namespace LoongEgg.KeyboardIndicator
{
    public class WindowManagerViewModel : BaseViewModel
    {
        public ICommand MinimizeCommand { get; private set; }
        public ICommand MaximizeCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }

        public WindowManagerViewModel()
        {
            CloseCommand = new RelayCommand<Window>(CloseWindow);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
