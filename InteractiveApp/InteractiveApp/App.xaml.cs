using System;
using InteractiveApp.ViewModels;
using WhiteMvvm;
using WhiteMvvm.Services.Locator;
using WhiteMvvm.Services.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace InteractiveApp
{
    public partial class App : WhiteApplication
    {
        public App()
        {
            Device.SetFlags(new string[] { "MediaElement_Experimental","Shapes_Experimental" });
            InitializeComponent();
            SetHomePage(new NavigationModal()
            {
                RootModal = new BasicModal()
                {
                    ViewModel = LocatorService.Instance.Resolve<MainViewModel>()
                }
            });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}