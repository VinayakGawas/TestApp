using TestApp.Model;
using TestApp.ViewModels;
using Xamarin.Forms;

namespace TestApp.Views
{
    public partial class HomePage : ContentPage
    {
        HomePageViewModel _viewModel;
        public HomePage()
        {
            InitializeComponent();
            _viewModel = BindingContext as HomePageViewModel;
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void VerifyButton_Clicked(object sender, System.EventArgs e)
        {
            var selectedObj = (sender as Button).BindingContext as StudentInfo;

            if (selectedObj != null && !selectedObj.IsAudited)
            {
                selectedObj.IsAudited = true;
                _viewModel.UpdateObject(selectedObj);
            }
        }
    }
}
