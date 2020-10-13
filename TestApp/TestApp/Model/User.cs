using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Model
{
    public class User : BindableBase
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        private string _role;
        public string Role
        {
            get { return _role; }
            set { SetProperty(ref _role, value); }
        }
    }
}
