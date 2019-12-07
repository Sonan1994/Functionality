using System.Collections.Generic;
using Funcionality.Interface;
using Funcionality.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Funcionality.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageMaster : ContentPage, IAssignMasterDetailPageViewModel
    {
        public ListView ListView;

        public MasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = MenuItemViewModel;
            ListView = MenuItemsListView;
        }

        public MasterDetailPageMasterViewModel MenuItemViewModel
        {
            get
            {
                return new MasterDetailPageMasterViewModel(
                    new List<MasterDetailPageMenuItem> {
                        new MasterDetailPageMenuItem { Id = 1, Title = "Home", TargetType = typeof(MasterDetailPageHome) },
                        new MasterDetailPageMenuItem { Id = 2, Title = "Scan QR", TargetType = typeof(MasterDetailPageScanQr) },
                        new MasterDetailPageMenuItem { Id = 3, Title = "History", TargetType = typeof(MasterDetailPageHistory) },
                        new MasterDetailPageMenuItem { Id = 4, Title = "Detail", TargetType = typeof(MasterDetailPageDetail) },
                        new MasterDetailPageMenuItem { Id = 5, Title = "Settings", TargetType = typeof(MasterDetailPageSettings) },
                        new MasterDetailPageMenuItem { Id = 6, Title = "About", TargetType = typeof(MasterDetailPageAbout) }
                    }
                );
            }
        }
    }
}