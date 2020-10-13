using Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TestApp.Model
{
    public class AddressInfo : BindableBase
    {
        private string _id;
        [PrimaryKey]
        public string AddressId
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        private string Line1;
        public string AddressLine1
        {
            get { return Line1; }
            set { SetProperty(ref Line1, value); }
        }
        private string _street;
        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }
        private string _country;
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }
        private string _postalCode;
        public string PostalCode
        {
            get { return _postalCode; }
            set { SetProperty(ref _postalCode, value); }
        }
        private string _studentID;
        public string StudentID
        {
            get { return _studentID; }
            set { SetProperty(ref _studentID, value); }
        }
    }
}
