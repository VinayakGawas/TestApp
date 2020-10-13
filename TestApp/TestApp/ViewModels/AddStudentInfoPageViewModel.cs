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
        public AddStudentInfoPageViewModel(INavigationService navigationService, IGenericRepo<StudentInfo> studentInfoRepo, IPageDialogService pageDialog) : base(navigationService, pageDialog)
        {
            _studentInfoRepo = studentInfoRepo;
            SaveCommand = new DelegateCommand(SaveInfo);
            studentInfo = new StudentInfo();
        }

        private void SaveInfo()
        {
            _studentInfoRepo.InsertOrReplace(studentInfo);
            NavigationService.GoBackAsync();
        }
    }
}
