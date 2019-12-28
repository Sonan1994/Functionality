using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Funcionality.ViewModels.Base;

namespace Funcionality.Services.Navigation
{
    public interface INavigationService
    {
        ViewModelBase PreviousPageViewModelBase { get; }

        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();
    }
}
