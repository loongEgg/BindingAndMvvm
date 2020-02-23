using LoongEgg.Presentation.Core;
using System.Windows;

namespace LoongEgg.Presentation.Controls
{
    public class FlyInCharListItemViewModel : BaseViewModel
    {
        public string Chars {
            get => _Chars;
            set  {
                _Chars = value;
                RaisePropertyChanged();
            }
        }
        private string _Chars;


        public int Hits {
            get => _Hits;
            set {
                Set(ref _Hits, value);
                HitsVisibility = Hits > 1 ? Visibility.Visible : Visibility.Hidden;
            }
        }
        private int _Hits;


        public Visibility HitsVisibility {
            get => _HitsVisibility;
            set => Set(ref _HitsVisibility, value);
        }
        private Visibility _HitsVisibility = Visibility.Hidden;


    }

    /// <summary>
    ///     <see cref="FlyInCharListItemViewModel"/>的设计时ViewModel
    /// </summary>
    /// <returns>
    ///     Single instance of <see cref="FlyInCharListItemViewModel"/>
    /// </returns>
    public class FlyInCharListControlItemDesignModel : FlyInCharListItemViewModel
    {
        public static FlyInCharListControlItemDesignModel Instance => new FlyInCharListControlItemDesignModel();

        public FlyInCharListControlItemDesignModel()
        {
            Chars = "X";
            Hits = 2;
        }
    }
}