using LoongEgg.Presentation.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LoongEgg.Presentation.Controls
{
    /// <summary>
    ///     View Model of Fly In Char List Control 
    /// </summary>
    public class FlyInCharListControlViewModel : BaseViewModel
    {
        /// <summary>
        ///     Chars Items of <see cref="FlyInCharListControlViewModel"/>
        /// </summary>
        public ObservableCollection<FlyInCharListItemViewModel> Items {
            get => _Items;
            set => Set(ref _Items, value);
        }
        private ObservableCollection<FlyInCharListItemViewModel> _Items;

    }

    /// <summary>
    ///     Design Model of <see cref="FlyInCharListControlViewModel"/>
    /// </summary>
    public class FlyInCharListControlDesignModel : FlyInCharListControlViewModel
    {
        public static FlyInCharListControlDesignModel Instance => new FlyInCharListControlDesignModel();

        public FlyInCharListControlDesignModel()
        {
            Items = new ObservableCollection<FlyInCharListItemViewModel>
            {
                new FlyInCharListItemViewModel{ Chars = "A", Hits = 1 },
                new FlyInCharListItemViewModel{ Chars = "A", Hits = 2 },
                new FlyInCharListItemViewModel{ Chars = "C", Hits = 3 }
            };
        }
    }
}
