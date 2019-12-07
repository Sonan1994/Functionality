using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Funcionality.ViewModels
{
    public class MasterDetailPageMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MasterDetailPageMenuItem> MenuItems { get; set; }

        public MasterDetailPageMasterViewModel(List<MasterDetailPageMenuItem> items)
        {
            MenuItems = new ObservableCollection<MasterDetailPageMenuItem>(items);
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
