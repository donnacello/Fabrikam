using FabrikamApp.View;
using FabrikamApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FabrikamApp
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate();
    }

    public partial class App : Application
    {
        public static NavigationPage NavigationPage { get; private set; }
        public static RootPage RootPage;

        public static bool MenuIsPresented
        {
            get
            {
                return RootPage.IsPresented;
            }
            set
            {
                RootPage.IsPresented = value;
            }
        }

        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }



        public App()
        {
            var navPage = new NavPage();
            NavigationPage = new NavigationPage(new HomePage()){
                                    BarBackgroundColor = Color.Teal};
            RootPage = new RootPage();
            RootPage.Master = navPage;
            RootPage.Detail = NavigationPage;
            MainPage = RootPage;
        }
    }

    public static class ViewModelLocator
    {
        static MenuViewModel menuVM;
        public static MenuViewModel MenuViewModel
            => menuVM ?? (menuVM = new MenuViewModel());
    }
}
