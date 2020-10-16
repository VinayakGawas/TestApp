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
        private StudentInfo _currentUser;
        public StudentInfo CurrentUser
        {
            get { return _currentUser; }
            set { SetProperty(ref _currentUser, value); }
        }

       

        public string UserRole { get; set; }
        public DelegateCommand AddInfoCommand { get; set; }
        public DelegateCommand LogoutCommand { get; set; }
        public IGenericRepo<StudentInfo> _studentRepo { get; set; }
        public IGenericRepo<AddressInfo> _addressRepo { get; set; }
        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialog,
            IGenericRepo<StudentInfo> studentRepo, IGenericRepo<AddressInfo> addressRepo) : base(navigationService, pageDialog)
        {
            UserRole = App.CurrentUser.Role;
            _addressRepo = addressRepo;
            _studentRepo = studentRepo;
            AddInfoCommand = new DelegateCommand(AddStudentInfo);
            LogoutCommand = new DelegateCommand(Logout);
            AllStudentsList = new ObservableCollection<StudentInfo>();
            CurrentUser = new StudentInfo();
            CurrentUser.address = new AddressInfo();
            LoadData();
        }
        internal void UpdateObject(StudentInfo selectedObj)
        {
            _studentRepo.Update(selectedObj);
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

                var data = AllStudentsList.FirstOrDefault(x=>x.UserId == App.CurrentUser.UserId);
                if (data == null)
                {
                    if(UserRole == "Student")
                        PageDialogService.DisplayAlertAsync("","Please fill Information","Ok");
                    else
                    {
                        PageDialogService.DisplayAlertAsync("", "No Information to show..!!", "Ok");
                    }
                }
                else
                {
                    CurrentUser = data;
                }
            }
        }

        private async void Logout()
        {
            var a = await PageDialogService.DisplayAlertAsync("Log Out?","Do you want to log out?","Yes","No");
            //await NavigationService.NavigateAsync("NavigationPage/LoginPage");
            await NavigationService.NavigateAsync("app:///NavigationPage/LoginPage");
        }

        private void AddStudentInfo()
        {
            //9662476093
            NavigationService.NavigateAsync(nameof(AddStudentInfoPage),new NavigationParameters { {"CurrentUser", CurrentUser } });
        }
       
    }
}
