using Gma.System.MouseKeyHook;
using System;
using System.Windows.Forms;

namespace LoongEgg.KeyboardMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            MouseMonitor();
            Console.ReadLine();
        }

        static void MouseMonitor()
        {
            MonitorHelper.ListenForMouseEvents();
            Application.Run(new ApplicationContext());
        }
    }

    public class MonitorHelper
    {
        public static void ListenForMouseEvents()
        {
            Hook.GlobalEvents().MouseClick += (sender, e)=>
            {
                Console.WriteLine($"Mouse {e.Button} clicked.");                
            };
            Hook.GlobalEvents().MouseDoubleClick += (sender, e) =>
            {
                Console.WriteLine($"{DateTime.Now.ToString("yyyyMMddHHmmssffff")} Mouse {e.Button} button double clicked.");
            };

            Hook.GlobalEvents().MouseDragFinished += (sender, e) =>
            {
                Console.WriteLine($"{DateTime.Now.ToString("yyyyMMddHHmmssffff")} Mouse {e.Button} dragged");
            };

            Hook.GlobalEvents().MouseWheel += (sender, e) =>
            {
                string scroll = e.Delta > 0 ? "Up" : "Down";
                Console.WriteLine($"{DateTime.Now.ToString("yyyyMMddHHmmssffff")} Mouse scroll {scroll}");
            };

            Hook.GlobalEvents().KeyDown += (sender, e) =>
            {
                Console.WriteLine($"{DateTime.Now.ToString("yyyyMMddHHmmssffff")} pressed {e.KeyCode}");
            };
        }
    }
}
