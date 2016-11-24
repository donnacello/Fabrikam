using FabrikamApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Settings;
using Microsoft.WindowsAzure.MobileServices;
using FabrikamApp.Services;
using System.Net.Http;

namespace FabrikamApp
{
    public partial class HomePage : ContentPage
    {
        bool authenticated = false;

        //private string clientID = "599176193540665";
        //private string redirectURI = "http://fabrikammenusuggestions.azurewebsites.net/.auth/login/facebook/callback";

        public HomePage()
        {
            //Create the view model and set as binding context
            BindingContext = new MenuViewModel();
            InitializeComponent();
        }



        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string userId = CrossSettings.Current.GetValueOrDefault("user", "");
            string token = CrossSettings.Current.GetValueOrDefault("token", "");

            if (!token.Equals("") && !userId.Equals(""))
            {
                MobileServiceUser user = new MobileServiceUser(userId);
                user.MobileServiceAuthenticationToken = token;
                AzureServices.AzureServicesInstance.AzureClient.CurrentUser = user;
                authenticated = true;
            }

            if (authenticated == true)
                this.loginButton.IsVisible = false;
        }

        async void loginButton_Clicked(object sender, EventArgs e)
        {
            if (App.Authenticator != null)
                authenticated = await App.Authenticator.Authenticate();

            if (authenticated == true)
            {
                this.loginButton.IsVisible = false;
                CrossSettings.Current.AddOrUpdateValue("user", AzureServices.AzureServicesInstance.AzureClient.CurrentUser.UserId);
                CrossSettings.Current.AddOrUpdateValue("token", AzureServices.AzureServicesInstance.AzureClient.CurrentUser.MobileServiceAuthenticationToken);
            }
        }



    }
}
