using System.Collections.Generic;
using System.Collections.ObjectModel;
using Funcionality.ViewModels.Base;

namespace Funcionality.ViewModels
{
    public class MasterDetailPageMasterViewModel : ViewModelBase
    {
        public ObservableCollection<MasterDetailPageMenuItem> MenuItems { get; set; }

        public MasterDetailPageMasterViewModel(List<MasterDetailPageMenuItem> items)
        {
            MenuItems = new ObservableCollection<MasterDetailPageMenuItem>(items);
        }
    }
}
