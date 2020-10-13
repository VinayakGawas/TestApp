using Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Model
{
    public class StudentInfo : BindableBase
    {
        private string _id;
        [PrimaryKey]
        public string StudentId
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }
        private string _class;
        public string Class
        {
            get { return _class; }
            set { SetProperty(ref _class, value); }
        }
        private AddressInfo addressInfo;
        [Ignore]
        public AddressInfo address
        {
            get { return addressInfo; }
            set { SetProperty(ref addressInfo, value); }
        }
        private DocumentsInfo _docuInfo;
        [Ignore]
        public DocumentsInfo docuInfo
        {
            get { return _docuInfo; }
            set { SetProperty(ref _docuInfo, value); }
        }
        private string _emailID;
        public string emailId
        {
            get { return _emailID; }
            set { SetProperty(ref _emailID, value); }
        }
        private string _contactNo;
        public string ContactNo
        {
            get { return _contactNo; }
            set { SetProperty(ref _contactNo, value); }
        }
        private bool _isAudited;
        public bool IsAudited
        {
            get { return _isAudited; }
            set { SetProperty(ref _isAudited, value); }
        }
    }
}
