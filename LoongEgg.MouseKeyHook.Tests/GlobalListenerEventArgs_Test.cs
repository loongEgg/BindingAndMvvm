using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;

namespace LoongEgg.MouseKeyHook.Tests
{
    [TestClass]
    public class GlobalListenerEventArgs_Test
    {
        // [TestMethod]
        public void GlobalMouseEventArgs_Test()
        {
            GlobalMouseEventArgs eventArgs;
            eventArgs = new GlobalMouseEventArgs(Mouse.LeftButton, MouseAction.Up);
            Assert.AreEqual("LeftButton: Up", eventArgs.ToString());

            eventArgs = new GlobalMouseEventArgs(Mouse.LeftButton, MouseAction.Down);
            Assert.AreEqual("LeftButton: Down", eventArgs.ToString());
        }

        [TestMethod]
        public void GlobalKeyEventArgs_Test()
        {
            GlobalKeyEventArgs eventArgs;

            eventArgs = new GlobalKeyEventArgs(Key.A, KeyAction.Down);
            Assert.AreEqual("<A>: Down", eventArgs.ToString());

            eventArgs = new GlobalKeyEventArgs(Key.A, KeyAction.Up);
            Assert.AreEqual("<A>: Up", eventArgs.ToString());

            eventArgs = new GlobalKeyEventArgs(Key.A, KeyAction.Pressed);
            Assert.AreEqual("<A>: Pressed", eventArgs.ToString());
        }
    }
}
