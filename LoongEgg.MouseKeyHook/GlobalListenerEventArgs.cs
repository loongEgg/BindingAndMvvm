using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace LoongEgg.MouseKeyHook
{
    /// <summary>
    /// 鼠标的按键定义
    /// </summary>
    public enum Mouse
    {
        /// <summary>
        /// 左键
        /// </summary>
        LeftButton,

        /// <summary>
        /// 右键
        /// </summary>
        RightButton,

        /// <summary>
        /// 中键
        /// </summary>
        MiddleButton,

        /// <summary>
        /// 滚轮
        /// </summary>
        Scroll
    }

    /// <summary>
    ///     鼠标动作
    /// </summary>
    public enum MouseAction
    {
        /// <summary>
        /// 按键抬起/滚轮向上
        /// </summary>
        Up,

        /// <summary>
        /// 按键按下/滚轮向下
        /// </summary>
        Down,

        /// <summary>
        /// 双击事件
        /// </summary>
        DoubleClick
    }

    /// <summary>
    ///     键盘动作
    /// </summary>
    public enum KeyAction
    {
        /// <summary>
        ///     按键抬起
        /// </summary>
        Up,

        /// <summary>
        ///     按键按下
        /// </summary>
        Down,

        /// <summary>
        ///     长按事件
        /// </summary>
        Pressed
    }

    /// <summary>
    ///     全局键盘/鼠标监听事件参数基类
    /// </summary>
    public abstract class GlobalListenerEventArgs<T, InputAction> 
        : EventArgs
        where T : Enum
        where InputAction : Enum
    {
        [Required]
        public KeyValuePair<T, InputAction> Target { get; private set; }

        /// <summary>
        /// Constructor of <see cref="GlobalMouseEventArgs"/>
        /// </summary>
        /// <param name="target"></param>
        public GlobalListenerEventArgs(T target, InputAction action)
            => Target = new KeyValuePair<T, InputAction>(target, action);
                 
        // returns like: <LeftButton>: Up
        public override string ToString()
            => $"<{Target.Key.ToString()}>: {Target.Value.ToString()}"; 
    }

    /// <summary>
    ///     全局鼠标事件参数
    /// </summary>
    public class GlobalMouseEventArgs : GlobalListenerEventArgs<Mouse, MouseAction>
    {
        public GlobalMouseEventArgs(Mouse target, MouseAction action)
            : base(target, action) {  }
    }

    /// <summary>
    ///     全局键盘事件参数
    /// </summary>
    public class GlobalKeyEventArgs : GlobalListenerEventArgs<Key, KeyAction>
    {
        public GlobalKeyEventArgs(Key target, KeyAction action)
            : base(target, action) { }

    }

}

  