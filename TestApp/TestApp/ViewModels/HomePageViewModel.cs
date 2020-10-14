using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Views;
using TestApp.Model;
using TestApp.Repo;
using System.Collections.ObjectModel;

namespace TestApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private ObservableCollection<StudentInfo> _allStudentsList;
        public ObservableCollection<StudentInfo> AllStudentsList
        {
            get { return _allStudentsList; }
            set { SetProperty(ref _allStudentsList, value); }
        }
        public DelegateCommand AddInfoCommand { get; set; }
        public DelegateCommand LogoutCommand { get; set; }
        public IGenericRepo<StudentInfo> _studentRepo { get; set; }
        public IGenericRepo<AddressInfo> _addressRepo { get; set; }
        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialog,
            IGenericRepo<StudentInfo> studentRepo, IGenericRepo<AddressInfo> addressRepo) : base(navigationService, pageDialog)
        {
            _addressRepo = addressRepo;
            _studentRepo = studentRepo;
            AddInfoCommand = new DelegateCommand(AddStudentInfo);
            LogoutCommand = new DelegateCommand(Logout);
            AllStudentsList = new ObservableCollection<StudentInfo>();
            LoadData();
        }

        private void LoadData()
        {
            var a = _studentRepo.QueryTable().ToList();
            if (a!= null)
            {
                foreach (var item in a)
                {
                    var address = _addressRepo.QueryTable().FirstOrDefault(x => x.StudentID == item.StudentId);
                    if (address != null)
                        item.address = address;
                }
                AllStudentsList = new ObservableCollection<StudentInfo>(a);
            }
        }

        private async void Logout()
        {
            var a = await PageDialogService.DisplayAlertAsync("Log Out?","Do you want to log out?","Yes","No");
            await NavigationService.NavigateAsync("app:///LoginPage");
        }

        private void AddStudentInfo()
        {
            NavigationService.NavigateAsync(nameof(AddStudentInfoPage));
        }
       
    }
}
