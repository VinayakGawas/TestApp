using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Model;
using TestApp.Repo;

namespace TestApp.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        private User user;
        public User _user
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }
        public DelegateCommand RegisterCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public IGenericRepo<User> _userRepo { get; set; }
        public SignUpPageViewModel(INavigationService navigationService, IPageDialogService pageDialog,
            IGenericRepo<User> userRepo) : base(navigationService, pageDialog)
        {
            _user = new User();
            RegisterCommand = new DelegateCommand(RegisterUser);
            CancelCommand = new DelegateCommand(CancelRegistration);
            _userRepo = userRepo;
        }

        private async void CancelRegistration()
        {
            var response = await PageDialogService.DisplayAlertAsync("Cancel0", "Do you want to cancel?\n All the data will be lost", "Yes","No");
            if (response)
                await NavigationService.GoBackAsync();
            else
                return;
        }

        public void RegisterUser()
        {
                var existingUser = _userRepo.QueryTable().FirstOrDefault(x => x.UserName == _user.UserName);
                if (existingUser == null)
                {
                    _user.UserId = Guid.NewGuid().ToString();
                    _user.Role = "Student";
                    _userRepo.Insert(_user);
                }
                else
                {
                    PageDialogService.DisplayAlertAsync("Duplicate User", "Sorry, this username is not available. \n Please try with different Username", "OK");
                    return;
                }
        }
    }
}
