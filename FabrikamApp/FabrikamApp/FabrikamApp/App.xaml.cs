using FabrikamApp.View;
using FabrikamApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FabrikamApp
{
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

        public App()
        {
            var navPage = new NavPage();
            NavigationPage = new NavigationPage(new HomePage());
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
