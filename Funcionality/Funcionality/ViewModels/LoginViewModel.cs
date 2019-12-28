using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Funcionality.ViewModels.Base;
using Xamarin.Forms;

namespace Funcionality.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private ICommand _btnLoginCommand;

        public LoginViewModel()
        {
            _btnLoginCommand = new Command(BtnLoginCommandHandler);
        }


        #region Properties

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ICommand BtnLoginCommand => _btnLoginCommand;


        #region Command Handlers

        private void BtnLoginCommandHandler()
        {

        }

        #endregion
    }
}
