using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoongEgg.Presentation.Demo
{
    /// <summary>
    /// ColorPicker.xaml 的交互逻辑
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        /*-----------------------------  Private Field  ------------------------------*/
        /// <summary>
        /// 前一个颜色
        /// </summary>
        public Color PreColor {
            get {
                if (PreColors.Count > 0)
                {
                    int last = PreColors.Count - 1;
                    Color ret = PreColors[last];
                    // PreColors.RemoveAt(last);
                    return ret;
                }
                else
                {
                    return Color;
                }
            }
        }

        public List<Color> PreColors { get; private set; } = new List<Color>();

        /*----------------------------------  Event  ---------------------------------*/
        /// <summary>
        /// 路由事件， 通知更高层次的父元素
        /// </summary>
        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent(
                    "ColorChanged",
                    RoutingStrategy.Bubble, // 注册为冒泡事件
                    typeof(RoutedPropertyChangedEventHandler<Color>),
                    typeof(ColorPicker)
                );

        /// <summary>
        /// 事件封装器， 用来公开事件， 关联/删除监听程序
        /// </summary>
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged {
            add => AddHandler(ColorChangedEvent, value);
            remove => RemoveHandler(ColorChangedEvent, value);
        }

        /*-------------------------------  Constructor  ------------------------------*/
        static ColorPicker()
        {
            CommandManager.RegisterClassCommandBinding(
                typeof(ColorPicker),
                new CommandBinding(
                    ApplicationCommands.Undo,
                    (s, e) => {
                        if (s is ColorPicker self) {
                            self.Color = self.PreColor;
                            self.RemoveLastColor(); } },
                    (s, e) => {
                        if (s is ColorPicker self) {
                            e.CanExecute = self.PreColors.Count > 0;
                        }
                    }
                )
            );
        }

        public ColorPicker()
        {
            InitializeComponent();
            Loaded += ColorPicker_Loaded;
            // PreColors.Add(Color);
            // InitCommands(); //在单个实例中注册Undo
        }

        private void ColorPicker_Loaded(object sender, RoutedEventArgs e)
        {
            PreColors.Add(Color);
        }

        /*---------------------------  Dependency Property  --------------------------*/
        [Description("拾取到的颜色"), Category("LoongEgg")]
        public static readonly DependencyProperty ColorProperty = 
            DependencyProperty.Register(
                nameof(Color),
                typeof(Color),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(
                    Colors.White,
                    new PropertyChangedCallback(OnColorChanged)));
        public Color Color {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        [Description("Red"), Category("LoongEgg")]
        public static readonly DependencyProperty RedProperty =
            DependencyProperty.Register(
                nameof(Red),
                typeof(byte),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(
                    (byte)255,
                    new PropertyChangedCallback(OnColorRGBChanged)));
        public byte Red {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        
        [Description("Green"), Category("LoongEgg")]
        public static readonly DependencyProperty GreenProperty =
            DependencyProperty.Register(
                nameof(Green),
                typeof(byte),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(
                    (byte)255,
                    new PropertyChangedCallback(OnColorRGBChanged)));
        public byte Green {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        [Description("Blue"), Category("LoongEgg")]
        public static readonly DependencyProperty BlueProperty =
            DependencyProperty.Register(
                nameof(Blue),
                typeof(byte),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(
                    (byte)255,
                    new PropertyChangedCallback(OnColorRGBChanged)));
        public byte Blue {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        /*-------------------------  Private Static Method  --------------------------*/
        /// <summary>
        /// Call-Back Method Raised On Color Changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ColorPicker self)
            {
                Color newColor = (Color)e.NewValue;
                Color oldColor = (Color)e.OldValue;

                self.Red = newColor.R;
                self.Green = newColor.G;
                self.Blue = newColor.B;

                self.OnColorChanged(newColor, oldColor);
            }
        }

        /// <summary>
        /// Call-Back Method Raised On Color RGB Component changed
        /// </summary>
        /// <param name="d"><see cref="ColorPicker"/></param>
        /// <param name="e"><see cref="DependencyProperty"/></param>
        private static void OnColorRGBChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ColorPicker self)
            {
                Color color = self.Color;

                if (e.Property == RedProperty)
                    color.R = (byte)e.NewValue;
                else if(e.Property == GreenProperty)
                    color.G = (byte)e.NewValue;
                else if (e.Property == BlueProperty)
                    color.B = (byte)e.NewValue;

                self.Color = color;
            }
        }

        /*-----------------------------  Private Method  -----------------------------*/
        /// <summary>
        /// 引起冒泡事件
        /// </summary>
        /// <param name="newColor"></param>
        /// <param name="oldColor"></param>
        private void OnColorChanged(Color newColor, Color oldColor)
        {
            RoutedPropertyChangedEventArgs<Color> args =
                new RoutedPropertyChangedEventArgs<Color>(oldColor, newColor)
                {
                    RoutedEvent = ColorPicker.ColorChangedEvent
                };
            RaiseEvent(args);
        }

        private void RemoveLastColor() {
            if (PreColors.Count > 0)
                PreColors.RemoveAt(PreColors.Count - 1);
        }
         
        /// <summary>
        /// 初始化命令
        /// </summary>
        private void InitCommands()
        {
            CommandBinding binding =
                new CommandBinding(
                    ApplicationCommands.Undo,
                    UndoCommand_Executed,
                    UndoCommand_CanExecute
            );
        }

        /// <summary>
        /// 回退命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
            => this.Color = (Color)PreColor;

        /// <summary>
        /// 可回退判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = PreColors.Count > 0;

        
        /// <summary>
        /// 当滑块操纵结束时增加一个前置颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            PreColors.Add(Color); 
        }

        //bool IsFirstTimeDrag = true;
        //private void Slider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        //{
        //    if (IsFirstTimeDrag)
        //    {

        //    }
        //}
    }

}
