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
        private string _userID;
        public string UserId
        {
            get { return _userID; }
            set { SetProperty(ref _userID, value); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
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
        private bool _isAudited = false;
        public bool IsAudited 
        {
            get { return _isAudited; }
            set { SetProperty(ref _isAudited, value); }
        }
        private byte[] _panImage;
        public byte[] PanCardImage
        {
            get { return _panImage; }
            set { SetProperty(ref _panImage, value); }
        }
        private string _panCardNumber;
        public string PanCardNumber
        {
            get { return _panCardNumber; }
            set { SetProperty(ref _panCardNumber, value); }
        }

        private byte[] _aadharImage;
        public byte[] AadharCardImage
        {
            get { return _aadharImage; }
            set { SetProperty(ref _aadharImage, value); }
        }
        private string _aardharCardNumber;
        public string AadharCardNumber
        {
            get { return _aardharCardNumber; }
            set { SetProperty(ref _aardharCardNumber, value); }
        }
    }
}
