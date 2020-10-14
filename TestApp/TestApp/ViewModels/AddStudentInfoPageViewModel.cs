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
    public class AddStudentInfoPageViewModel : ViewModelBase
    {
        private StudentInfo _studentInfo;
        public StudentInfo studentInfo
        {
            get { return _studentInfo; }
            set { SetProperty(ref _studentInfo, value); }
        }
        public DelegateCommand SaveCommand { get; set; }
        public IGenericRepo<StudentInfo> _studentInfoRepo { get; set; }
        public IGenericRepo<AddressInfo> _addressRepo { get; set; }
        public AddStudentInfoPageViewModel(INavigationService navigationService, IPageDialogService pageDialog,
            IGenericRepo<StudentInfo> studentInfoRepo, IGenericRepo<AddressInfo> addressInfoRepo) : base(navigationService, pageDialog)
        {
            _studentInfoRepo = studentInfoRepo;
            _addressRepo = addressInfoRepo;
            SaveCommand = new DelegateCommand(SaveInfo);
            studentInfo = new StudentInfo();
            studentInfo.address = new AddressInfo();
        }

        private async void SaveInfo()
        {
            var a =await PageDialogService.DisplayAlertAsync("","Do you want to save this?","Yes","No");
            if (a)
            {
                studentInfo.StudentId = Guid.NewGuid().ToString();
                studentInfo.address.AddressId = Guid.NewGuid().ToString();
                studentInfo.address.StudentID = studentInfo.StudentId;
                _studentInfoRepo.InsertOrReplace(studentInfo);
                _addressRepo.InsertOrReplace(studentInfo.address);
                await NavigationService.GoBackAsync();
            }
        }
    }
}
