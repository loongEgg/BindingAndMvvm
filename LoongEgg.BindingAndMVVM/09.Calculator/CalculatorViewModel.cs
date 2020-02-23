using System;
using System.Diagnostics;
using System.Windows.Input;

/* wechat: InnerGeeker
 * wechat/bilibili: 香辣恐龙蛋
 */

namespace LoongEgg.BindingAndMVVM
{
    public class CalculatorViewModel : LoongEgg.Presentation.Core.BaseViewModel
    {
        /*-------------------------  Public Property  -------------------------*/
        /// <summary>
        /// 运算符左侧的数据
        /// </summary> 
        public int Left { get; set; }

        /// <summary>
        /// 运算符右侧的数据
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        /// 计算结果
        /// </summary>
        public string Answer {
            get => _Answer;
            set {
                Set(ref _Answer, value);
            }
        }
        private string _Answer;

        /// <summary>
        /// [<see cref="RelayCommand"/>]计算命令
        /// </summary>
        public ICommand CalculateCommand { get; private set; }

        /* wechat: InnerGeeker
         * wechat/bilibili: 香辣恐龙蛋
         */

        /*---------------------------  Constructor  ---------------------------*/
        public CalculatorViewModel()
        {
            CalculateCommand = new RelayCommand(
                Calculate,
                (e) => true // 永远返回True的Fake方法
                );
        }

        /*-------------------------  Private Methods  -------------------------*/
        /// <summary>
        /// Calculate the answer
        /// </summary>
        /// <param name="obj"></param> 
        private void Calculate(object obj)
        {
            string calc = obj.ToString();

            try
            {
                switch (calc)
                {
                    case "+": Answer = (Left + Right).ToString(); break;
                    case "-": Answer = (Left - Right).ToString(); break;
                    case "*": Answer = (Left * Right).ToString(); break;
                    case "/": Answer = (Left / Right).ToString(); break;

                    // NOTE:
                    //      In Debug:   the button [^] will raise a break
                    //      In Release: the button [^] will throw a NotImplementedException
                    //      Enjoy the magic of the System.Diagnostics.Debugger;
                    default:
                        Debugger.Break(); // 
                        throw new NotImplementedException($"Unkown operator: {calc}");  
                }
            }
            catch (Exception ex)
            {
                Answer = ex.Message;
            }             
        } 
    }
}
