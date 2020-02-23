using System;

namespace LoongEgg.MouseKeyHook
{
    /// <summary>
    /// 监听的输入类型， 可以用 | 位或运算运算
    /// </summary>
    [Flags]
    public enum GlobalListeners
    {
        /// <summary>
        /// 仅监控鼠标
        /// </summary>
        MouseListener = 1,  // bin: 0001

        /// <summary>
        /// 仅监控键盘
        /// </summary>
        KeyListener = 2,    // bin: 0010

        // NOTE: 继续往下增加直接在上一个乘以2就好
    }
}
