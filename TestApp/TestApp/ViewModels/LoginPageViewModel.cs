using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Model;
using TestApp.Repo;
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
        public User ExistingUser { get; set; }
        public DelegateCommand LoginCommand { get; set; }
        public IGenericRepo<User> _userRepo { get; set; }
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialog
            ,IGenericRepo<User> userRepo) : base(navigationService, pageDialog)
        {
            _userRepo = userRepo;
            _user = new User();
            ExistingUser = new User();
            LoginCommand = new DelegateCommand(Login);
        }
        internal void CheckUser()
        {
            if (!string.IsNullOrEmpty(user.UserName))
            {
                if (user.UserName.ToLower() != "admin")
                {
                    var user = _userRepo.QueryTable().FirstOrDefault(x => x.UserName == _user.UserName);
                    if (user != null)
                    {
                        ExistingUser = user;
                    }
                    else
                    {
                        PageDialogService.DisplayAlertAsync("", "User does not exist please register to continue.", "OK");
                    }
                }
            }
        }
        internal void NavigateToSignUp()
        {
            NavigationService.NavigateAsync(nameof(SignUpPage));
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

            if ((_user.UserName == ExistingUser.UserName && _user.Password == ExistingUser.Password)||
                (_user.UserName.ToLower() == "admin" && _user.Password == "123"))
            {
                App.CurrentUser = ExistingUser;
                if (_user.UserName.ToLower() == "admin")
                {
                    App.CurrentUser.UserName = "Admin";
                    App.CurrentUser.Role = "Admin";
                }
                
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
