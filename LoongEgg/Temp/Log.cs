using System.Windows;

namespace LoongEgg
{
    public class Log
    {
        static Window Window = null;
        static Log()
        {
            if (Window == null)
            {
                Window = new Window();
            }
        }

        public Log()
        {
             

                Window.Show(); 
        }

        ~Log()
        {
            Window.Close();
        }
    }
}
