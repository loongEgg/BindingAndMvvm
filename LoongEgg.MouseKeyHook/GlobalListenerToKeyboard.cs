using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace LoongEgg.MouseKeyHook
{
    /// <summary>
    ///     Windows messages?
    /// </summary>
    public enum WM
    {
        /// <summary>
        ///     当Alt键没有按下时的键盘输入
        ///     Posted to the window with the keyboard focus when a nonsystem key is pressed. A nonsystem 
        ///     key is a key that is pressed when the ALT key is not pressed.
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/zh-cn/windows/win32/inputdev/wm-keydown?redirectedfrom=MSDN
        /// </remarks>
        KEYDOWN = 0x0100,

        KEYUP = 0x0101,

        /// <summary>
        ///     当Alt键同时按下时的键盘输入
        ///     posted to the window with the keyboard focus when the user presses the F10 key (which activates 
        ///     the menu bar) or holds down the ALT key and then presses another key. It also occurs when no 
        ///     window currently has the keyboard focus; in this case, the WM_SYSKEYDOWN message is sent to 
        ///     the active window. The window that receives the message can distinguish between these two contexts
        ///     by checking the context code in the lParam parameter.
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/zh-cn/windows/win32/inputdev/wm-syskeydown
        /// </remarks>
        SYSKEYDOWN = 0x0104,

        SYSKEYUP = 0x0105,
    }

    /// <summary>
    ///     全局键盘监听器
    /// </summary>
    public class GlobalListenerToKeyboard : BaseGlobalListener
    {
        /*-------------------------  Public Property  -------------------------*/
        /// <summary>
        ///      系统输入事件， 只会返回<see cref="GlobalMouseEventArgs"/>/<see cref="GlobalKeyEventArgs"/>
        /// </summary>
        public event EventHandler<GlobalKeyEventArgs> ListenerEvent;

        /// <summary>
        ///     键盘状态记录表
        /// </summary>
        private static Dictionary<string, KeyAction> KeysStatus;

        /// <summary>
        ///     初始化键盘记录表
        /// </summary>
        static GlobalListenerToKeyboard()
        {
            if (KeysStatus == null)
            {
                KeysStatus = new Dictionary<string, KeyAction>();

                //var Keys = Enum.GetValues(typeof(Key));
                //foreach (Key key in Keys)
                //{
                //    // WPF的Key中有使用同一个索引号的键值：）
                //    if (!KeysStatus.ContainsKey(key.ToString()))
                //    {
                //        KeysStatus.Add(key.ToString(), KeyAction.Up);
                //    }
                //}

                // (Array => List).ForEach()
                Enum.GetValues(typeof(Key)).OfType<Key>().ToList()
                    .ForEach(
                        key =>
                        {
                            // NOTE: WPF的Key中有使用同一个索引号的键值：）
                            if (!KeysStatus.ContainsKey(key.ToString()))
                                KeysStatus.Add(key.ToString(), KeyAction.Up);
                        }
                    );
            }
        }

        /// <summary>
        ///     Constructor of <see cref="GlobalListenerToKeyboard"/>
        /// </summary>
        public GlobalListenerToKeyboard() : base(IdHooks.WH_KEYBOARD_LL) { }

        protected override IntPtr HookCallBack(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0) // 大于等于0才是正确的消息
            {
                // 虚拟键盘码转位WPF中的键盘值
                Key key = KeyInterop.KeyFromVirtualKey(Marshal.ReadInt32(lParam));
                string index = key.ToString();

                // 按下事件
                if (wParam == (IntPtr)WM.KEYDOWN || wParam == (IntPtr)WM.SYSKEYDOWN)
                {
                    if (KeysStatus[index] == KeyAction.Down)
                    {
                        KeysStatus[index] = KeyAction.Pressed;
                        ListenerEvent?.Invoke(this, new GlobalKeyEventArgs(key, KeyAction.Pressed));
                    }
                    else if (KeysStatus[index] == KeyAction.Pressed)
                    {
                        // do nothing
                    }
                    else if (KeysStatus[index] == KeyAction.Up)
                    {
                        KeysStatus[index] = KeyAction.Down;
                        ListenerEvent?.Invoke(this, new GlobalKeyEventArgs(key, KeyAction.Down));
                    }
                }
                // 抬起事件
                if (wParam == (IntPtr)WM.KEYUP || wParam == (IntPtr)WM.SYSKEYUP)
                {
                    KeysStatus[index] = KeyAction.Up;
                    ListenerEvent?.Invoke(this, new GlobalKeyEventArgs(key, KeyAction.Up));
                }
                 
            }
            return CallNextHookEx(nCode, wParam, lParam);
        }
    }
}
