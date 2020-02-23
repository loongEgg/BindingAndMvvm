using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoongEgg.MouseKeyHook.Tests
{
    [TestClass]
    public class GlobalListener_Test
    {
        GlobalListenerManager Listener;

        /// <summary>
        /// 测试类的第一个启动方法，对类内的资源数据进行初始化
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Listener = new GlobalListenerManager(
                GlobalListeners.MouseListener | GlobalListeners.KeyListener
            );

        }

        /// <summary>
        /// 检查监听器类型
        /// </summary>
        [TestMethod]
        public void InputListener_TypeCheck()
        {
            GlobalListenerManager listener;
             
            listener = new GlobalListenerManager(
                GlobalListeners.MouseListener
            );
            Assert.AreEqual(1, (int)listener.InputListener);

            listener = new GlobalListenerManager(
               GlobalListeners.KeyListener
           );
            Assert.AreEqual(2, (int)listener.InputListener);

            listener = new GlobalListenerManager(
                GlobalListeners.MouseListener | GlobalListeners.KeyListener
            );
            Assert.AreEqual(3, (int)listener.InputListener);
        }

    }
}
