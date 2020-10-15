using TestApp.ViewModels;
using Xamarin.Forms;

namespace TestApp.Views
{
    public partial class SignUpPage : ContentPage
    {
        SignUpPageViewModel _viewModel;
        public SignUpPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as SignUpPageViewModel;
            ConfirmPasswordEntry.Unfocused += ConfirmPasswordEntry_Unfocused; ;
            ConfirmPasswordEntry.TextChanged += ConfirmPasswordEntry_TextChanged; ;
        }

        private void ConfirmPasswordEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (PasswordEntry.Text == ConfirmPasswordEntry.Text)
            {
                _viewModel._user.Password = ConfirmPasswordEntry.Text;
                ErrorLabel.IsVisible = false;
            }
            else
                ErrorLabel.IsVisible = true;
        }

        private void ConfirmPasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PasswordEntry.Text == ConfirmPasswordEntry.Text)
                ErrorLabel.IsVisible = false;
            else
                ErrorLabel.IsVisible = true;
        }
        private async void submitBtn_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(UserNameEntry.Text))
            {
                await DisplayAlert("Sorry","UserName cannot be empty..!","OK");
                return;
            }
            if (string.IsNullOrEmpty(PasswordEntry.Text))
            {
                await DisplayAlert("Sorry", "Password cannot be empty..!", "OK");
                return;
            }

            if (PasswordEntry.Text == ConfirmPasswordEntry.Text)
            {
                _viewModel._user.Password = ConfirmPasswordEntry.Text;
                _viewModel.RegisterUser();
            }
            else
                ErrorLabel.IsVisible = true;
        }
    }
}
