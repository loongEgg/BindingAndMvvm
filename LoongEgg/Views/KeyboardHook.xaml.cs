using LoongEgg.MouseKeyHook;
using LoongEgg.Presentation.Controls;
using LoongEgg.Presentation.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LoongEgg
{
    /// <summary>
    /// KeyboardHook.xaml 的交互逻辑
    /// </summary>
    public partial class KeyboardHook : Window
    {

        public KeyboardHook()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            title.Visibility = Visibility.Visible;
            border.BorderBrush = new SolidColorBrush(Color.FromRgb(0x00, 0x7A, 0xCC));
            mainBorder.CornerRadius = new CornerRadius(0, 0, 18, 18);
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            title.Visibility = Visibility.Hidden;
            border.BorderBrush = new SolidColorBrush(Colors.Transparent);
            mainBorder.CornerRadius = new CornerRadius(18, 18, 18, 18);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public class KeyboardHookViewModel : BaseViewModel, IDisposable
    {
        /// <summary>
        ///     Ctrl键按下状态
        /// </summary>
        public bool IsCtrlPressed {
            get => _IsCtrlPressed;
            set => Set(ref _IsCtrlPressed, value);
        }
        private bool _IsCtrlPressed = false;

        /// <summary>
        ///     Shift键按下状态
        /// </summary>
        public bool IsShiftPressed {
            get => _IsShiftPressed;
            set => Set(ref _IsShiftPressed, value);
        }
        private bool _IsShiftPressed = false;

        /// <summary>
        ///     Alt键按下状态
        /// </summary>
        public bool IsAltPressed {
            get => _IsAltPressed;
            set {
                Set(ref _IsAltPressed, value);
            }
        }
        private bool _IsAltPressed = false;

        /// <summary>
        ///     Tab键按下状态
        /// </summary>
        public bool IsTabPressed {
            get => _IsTabPressed;
            set => Set(ref _IsTabPressed, value); 
        }
        private bool _IsTabPressed; 

        public ICommand CommandEnabled { get; protected set; }

        /// <summary>
        ///     Chars Items of <see cref="FlyInCharListControlViewModel"/>
        /// </summary>
        public ObservableCollection<FlyInCharListItemViewModel> Items {
            get => _Items;
            set => Set(ref _Items, value);
        }
        private ObservableCollection<FlyInCharListItemViewModel> _Items 
             = new ObservableCollection<FlyInCharListItemViewModel>()
            {
                new FlyInCharListItemViewModel{ Chars="A", Hits = 3 },
            };

        /// <summary>
        /// 目前仅实现键盘的全局监听
        /// </summary>
        private GlobalListenerManager GlobalListenerManager;
         
        // TODO: Binding CornerRadius in view model
        public CornerRadius MainCornerRadius {
            get => _MainCornerRadius;
            set => Set(ref _MainCornerRadius, value);
        }
        private CornerRadius _MainCornerRadius = new CornerRadius(30, 30, 18, 18);
         
        /// <summary>
        /// Flag of disposed
        /// </summary>
        private bool disposed;


        public bool CanRecord {
            get => _CanRecord;
            set {
                Set(ref _CanRecord, value);
                if (CanRecord)
                {
                    GlobalListenerManager.StopListen();
                    GlobalListenerManager.StartListen(); 
                }
                else
                {
                    GlobalListenerManager.StopListen();
                }
            }
        }
        private bool _CanRecord = true;
         
        public KeyboardHookViewModel()
        {
            GlobalListenerManager = new GlobalListenerManager();
            GlobalListenerManager.KeyboardListener.ListenerEvent += KeyboardListener_ListenerEvent;
            GlobalListenerManager.StartListen();

            CommandEnabled = new RelayCommand((obj) => CanRecord = !CanRecord);

            Items = new ObservableCollection<FlyInCharListItemViewModel>();

            ReplaceName = new Dictionary<string, string>
            {
                { "Oem3",           "`"},
                 
                { "OemMinus",      "-"},
                { "OemPlus",       "="},

                { "OemOpenBrackets", "["},
                { "Oem6",            "]"},
                { "Oem5",           "\\"},

                { "Oem1",         ";"},
                { "OemQuotes",    "'"},
                { "Return",   "Enter"},

                { "OemComma",    ","},
                { "OemPeriod",   "."},
                { "OemQuestion", "/"},

                { "Left",  "<-"},
                { "Right", "->"},

                { "Down", "DW"},
                { "Up",   "UP"},

                { Key.PageDown.ToString(), "PD"},
                { Key.PageUp.ToString(),   "PU"},

                { "Space",   " "},

                { "Divide",     "/"},
                { "Multiply",   "*"},
                { "Subtract",  "-"},
                { "Add",        "+"},

            };

        }

        public void Dispose() => Dispose(true);

        private void Dispose(bool disposing)
        {
            if (disposed || disposing)
                return;

            GlobalListenerManager.StopListen();
            disposed = true;
        }

        ~KeyboardHookViewModel() => Dispose(false);
         
        private static Dictionary<string, string> ReplaceName;
        private void KeyboardListener_ListenerEvent(object sender, EventArgs e)
        {
            if (e is GlobalKeyEventArgs args)
            {
                if (Items.Count >= 12 && args.Target.Value == KeyAction.Down)
                    Items = new ObservableCollection<FlyInCharListItemViewModel>();

                // If the key is modifiers: Ctrl Shift Alt Tab
                switch (args.Target.Key)
                {
                    case Key.LeftShift:
                    case Key.RightShift:
                        {
                            if (args.Target.Value == KeyAction.Pressed
                                || args.Target.Value == KeyAction.Down) 
                                IsShiftPressed = true; 
                           else 
                                IsShiftPressed = false; 
                            return;
                        }

                    case Key.LeftCtrl:
                    case Key.RightCtrl:
                        {
                            if (args.Target.Value == KeyAction.Pressed
                                || args.Target.Value == KeyAction.Down) 
                                IsCtrlPressed = true; 
                            else 
                                IsCtrlPressed = false; 
                            return;
                        }

                    case Key.LeftAlt:
                    case Key.RightAlt:
                        {
                            if (args.Target.Value == KeyAction.Pressed
                                || args.Target.Value == KeyAction.Down) 
                                IsAltPressed = true; 
                            else 
                                IsAltPressed = false; 
                            return;
                        }
                    case Key.Tab:
                        {
                            if (args.Target.Value == KeyAction.Pressed
                                || args.Target.Value == KeyAction.Down)
                                IsTabPressed = true;
                            else
                                IsTabPressed = false;
                            return;
                        }
                    case Key.CapsLock:
                        return;
                    case Key.Delete:
                    case Key.Enter:
                        Items = new ObservableCollection<FlyInCharListItemViewModel>();
                        return;

                    default:
                        break;
                }

                // If the key action is down & the key is NOT Ctrl Shft Alt
                if (args.Target.Value == KeyAction.Down)
                {
                    switch (args.Target.Key)
                    {
                        case Key.Back:
                            {
                                if (Items.Count > 0)
                                {
                                    int last = Items.Count - 1;
                                    if (Items[last].Hits > 1) 
                                        Items[last].Hits -= 1; 
                                    else 
                                        Items.RemoveAt(last); 
                                }
                                return;
                            }
                        default:
                            {
                                string c = args.Target.Key.ToString();
                                c = c.Length == 2 ? c.Replace("D", string.Empty) : c;
                                if (ReplaceName.ContainsKey(c))
                                    c = ReplaceName[c];
                                int last = Items.Count - 1;
                                if (last >= 0 && Items[last].Chars == c)
                                {
                                    if (Items[last].Chars == " ")
                                        return;

                                    Items[last].Chars = c; 

                                    if (Items[last].Chars.Length >= 2 )
                                        return;
                                    Items[last].Hits += 1;
                                }
                                else
                                {
                                    Items.Add(new FlyInCharListItemViewModel
                                    {
                                        Chars = c,
                                        Hits = 1
                                    });
                                } 
                            }
                            return;
                    }
                }

            }
        }
    }
}
