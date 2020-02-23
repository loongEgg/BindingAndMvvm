namespace LoongEgg.BindingAndMVVM
{
    public class MathViewModel : LoongEgg.Presentation.Core.BaseViewModel
    {
        /// <summary>
        /// 运算符左端项
        /// </summary>
        public int Left {
            get => _Left;
            set {
                Set(ref _Left, value);

                // 通知前端Answer变了
                RaisePropertyChanged(nameof(Answer));
            }
        }
        private int _Left;

        /// <summary>
        /// 运算符右端项
        /// </summary>
        public int Right {
            get { return _Right; }
            set {
                // 设置_Right的值，并通知前端Right变了
                Set(ref _Right, value);
                // 通知前端Answer变了
                RaisePropertyChanged(nameof(Answer));
            }
        }
        private int _Right;

        /// <summary>
        /// 计算结果
        /// </summary>
        public int Answer => Left + Right;

    }
}
