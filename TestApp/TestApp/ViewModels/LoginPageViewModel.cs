using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Model;
using TestApp.Views;

namespace TestApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private User user;
        public User _user
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }
        public DelegateCommand LoginCommand { get; set; }
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService, pageDialog)
        {
            _user = new User();
            LoginCommand = new DelegateCommand(Login);
        }

        private void Login()
        {
            if (string.IsNullOrEmpty(_user.UserName))
            {
                PageDialogService.DisplayAlertAsync("", "User Name cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrEmpty(_user.Password))
            {
                PageDialogService.DisplayAlertAsync("", "Password cannot be empty", "OK");
                return;
            }

            if ((_user.UserName.ToLower() == "student" || _user.UserName.ToLower() == "admin") && _user.Password =="123")
            {
                NavigationService.NavigateAsync(nameof(HomePage));
            }
            else
            {
                PageDialogService.DisplayAlertAsync("", "Wrong username and Password.", "OK");
                return;
            }
        }
    }
}
