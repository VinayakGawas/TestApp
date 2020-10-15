using Prism;
using Prism.Ioc;
using TestApp.ViewModels;
using TestApp.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using TestApp.Model;
using TestApp.Helpers;
using TestApp.Repo;

namespace TestApp
{
    public partial class App
    {
        public User CurrentUser { get; set; }
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            DBHelper.CreateTables();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IGenericRepo<StudentInfo>, GenericRepo<StudentInfo>>();
            containerRegistry.RegisterSingleton<IGenericRepo<AddressInfo>, GenericRepo<AddressInfo>>();
            containerRegistry.RegisterSingleton<IGenericRepo<DocumentsInfo>, GenericRepo<DocumentsInfo>>();
            containerRegistry.RegisterSingleton<IGenericRepo<User>, GenericRepo<User>>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<AddStudentInfoPage, AddStudentInfoPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
        }
    }
}
