using System;

namespace LoongEgg.MouseKeyHook
{
    // TODO: 实现鼠标监听器
    /// <summary>
    ///     全局鼠标监听器
    /// </summary>
    public class GlobalListenerToMouse : BaseGlobalListener
    {
        /*-------------------------  Public Property  -------------------------*/
        /// <summary>
        ///      系统输入事件， 只会返回<see cref="GlobalMouseEventArgs"/>/<see cref="GlobalKeyEventArgs"/>
        /// </summary>
        // public event EventHandler<EventArgs> ListenerEvent;

        public GlobalListenerToMouse() : base(IdHooks.WH_MOUSE_LL) {
            throw new NotImplementedException();
        }

        protected override IntPtr HookCallBack(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return CallNextHookEx(nCode, wParam, lParam);
        }

    }
}
