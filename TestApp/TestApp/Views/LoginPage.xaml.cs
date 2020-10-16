using TestApp.ViewModels;
using Xamarin.Forms;

namespace TestApp.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginPageViewModel _viewModel;
        public LoginPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as LoginPageViewModel;
            UserNameEntry.Unfocused += UserNameEntry_Unfocused;
        }

        private void UserNameEntry_Unfocused(object sender, FocusEventArgs e)
        {
            _viewModel.CheckUser();
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var response =await DisplayAlert("","Only for students, Are you a student?","Yes","No");
            if (response)
            {
                _viewModel.NavigateToSignUp();
            }
        }
    }
}
