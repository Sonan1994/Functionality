

using System.Threading.Tasks;
using Funcionality.ViewModels.Base;

namespace Funcionality.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public ViewModelBase PreviousPageViewModelBase => throw new System.NotImplementedException();

        public Task InitializeAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            throw new System.NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveBackStackAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveLastFromBackStackAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
