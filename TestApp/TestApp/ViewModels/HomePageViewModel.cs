using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Views;

namespace TestApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public DelegateCommand AddInfoCommand { get; set; }
        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService, pageDialog)
        {
            AddInfoCommand = new DelegateCommand(AddStudentInfo);
        }

        private void AddStudentInfo()
        {
            NavigationService.NavigateAsync(nameof(AddStudentInfoPage));
        }
    }
}
