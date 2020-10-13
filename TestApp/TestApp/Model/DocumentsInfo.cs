using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Model
{
    public class DocumentsInfo : BindableBase
    {
        private string _docuId;
        public string DocumentId
        {
            get { return _docuId; }
            set { SetProperty(ref _docuId, value); }
        }
        private byte[] _docuImage;
        public byte[] DocuImage
        {
            get { return _docuImage; }
            set { SetProperty(ref _docuImage, value); }
        }
        private string _docuNumber;
        public string DocuNumber
        {
            get { return _docuNumber; }
            set { SetProperty(ref _docuNumber, value); }
        }
        private string _docuName;
        public string DocuName
        {
            get { return _docuName; }
            set { SetProperty(ref _docuName, value); }
        }
    }
}
