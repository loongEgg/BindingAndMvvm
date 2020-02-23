using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace LoongEgg.MouseKeyHook
{

    /// <summary>
    /// 全局键盘 & 鼠标监听器
    /// </summary>
    public class GlobalListenerManager
    {
        /// <summary>
        /// 定义监听器类型
        /// </summary>
        [Required(ErrorMessage = "InputListener Type Is NOT Defined!")]// [Required] Specifies that a data field value is required.
        public GlobalListeners InputListener { get; private set; }
          
        /// <summary>
        ///     键盘监听器
        /// </summary>
        public GlobalListenerToKeyboard KeyboardListener { get; private set; }

        // TODO: 增加鼠标监听事件

        /// <summary>
        ///     Constructor of <see cref="GlobalListenerManager"/>
        /// </summary>
        /// <param name="inputListeners">
        ///     默认同时开启键盘和鼠标监听事件
        /// </param>
        public GlobalListenerManager(
            GlobalListeners inputListeners = GlobalListeners.KeyListener | GlobalListeners.MouseListener )
        {
            
            InputListener = inputListeners;
            switch (InputListener)
            {
                case GlobalListeners.MouseListener: 
                    break;
                case GlobalListeners.KeyListener:
                    KeyboardListener = new GlobalListenerToKeyboard(); break; 

                // TODO: 完成鼠标监听事件初始化
                case GlobalListeners.MouseListener | GlobalListeners.KeyListener:
                    KeyboardListener = new GlobalListenerToKeyboard(); break;
                default:
                    Debugger.Break();
                    break;
            }
        }

        /// <summary>
        ///     开始监听
        /// </summary>
        public void StartListen()
        { 
            KeyboardListener.SetHook();
        }

        /// <summary>
        ///     停止监听
        /// </summary>
        public void StopListen()
        {
            KeyboardListener.UnHook();
        }

    }
}
