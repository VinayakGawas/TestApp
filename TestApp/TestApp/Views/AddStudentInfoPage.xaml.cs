using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using Xamarin.Forms;

namespace TestApp.Views
{
    public partial class AddStudentInfoPage : ContentPage
    {
        public AddStudentInfoPage()
        {
            InitializeComponent();
        }

        private async void UploadAadharCardButton_Clicked(object sender, System.EventArgs e)
        {
            //await CrossMedia.Current.Initialize();

            //if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            //{
            //    DisplayAlert("No Camera", ":( No camera available.", "OK");
            //    return;
            //}

            //var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //{
            //    Directory = "Sample",
            //    Name = "test.jpg"
            //});

            //if (file == null)
            //    return;

            //await DisplayAlert("File Location", file.Path, "OK");

            //AadharImage.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});
        }

        private async void UploadPanCardButton_Clicked(object sender, System.EventArgs e)
        {
            FileData fileData = await CrossFilePicker.Current.PickFile();
            if (fileData == null)
                return; // user canceled file picking

            string fileName = fileData.FileName;
            string contents = System.Text.Encoding.UTF8.GetString(fileData.DataArray);

            System.Console.WriteLine("File name chosen: " + fileName);
            System.Console.WriteLine("File data: " + contents);
        }
    }
}
