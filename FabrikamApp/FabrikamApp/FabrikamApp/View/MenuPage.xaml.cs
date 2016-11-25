using FabrikamApp.Model;
using FabrikamApp.Services;
using FabrikamApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FabrikamApp.View
{
    public partial class MenuPage : ContentPage
    {

        public MenuPage()
        {
            InitializeComponent();
            ViewMenu();
            //add an event to the ListViewSpeakers to get notified when an item is selected
            //ListViewMenu.ItemSelected += ListViewMenu_ItemSelected;
        }

        private async void ViewMenu()
        {
            loading.IsRunning = true;
            List<Menu> menu = await AzureServices.AzureServicesInstance.GetMenu();
            ListViewMenu.ItemsSource = menu;
            loading.IsRunning = false;
        }

        private void rex_Clicked(object sender, System.EventArgs e)
        {
            App.RootPage.Detail = new NavigationPage(new SuggestionsPage())
            {
                BarBackgroundColor = Color.Teal
            };
            App.MenuIsPresented = false;
        }


        private async void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            loading.IsRunning = true;
            var menuItem = e.SelectedItem as Menu;
            //check to see if the selected item is not null
            if (menuItem == null)
                return;
            await MenuViewModel.ShowNF(menuItem.Name);

            ListViewMenu.SelectedItem = null;
            loading.IsRunning = false;

            //using (HttpClient client = new HttpClient())
            //{
            //    string url = "https://api.nutritionix.com/v1_1/search/" + menuItem.Name + "?results=0:1"
            //        + "&fields=item_name,nf_calories,nf_cholesterol,nf_sodium&appId=023582a7&appKey=ac44e6c6b65e3dd4182fb99cbd9b652a";
            //    //grab json from server
            //    var json = await client.GetStringAsync(url.Replace(" ", "%20"));
            //    //deserialize the json and turn it into a list of dishes with Json.NET
            //    NutritionFacts.RootObject items = JsonConvert.DeserializeObject<NutritionFacts.RootObject>(json);
            //    List<NutritionFacts.Hit> hits = items.hits;

            //    string calories = "Calories: " + hits[0].fields.nf_calories.ToString("N2");
            //    string cholesterol = "Cholesterol" + hits[0].fields.nf_cholesterol.ToString("N2");
            //    string sodium = "Sodium" + hits[0].fields.nf_sodium.ToString("N2");

            //    await DisplayAlert("Nutrition Facts", calories + Environment.NewLine + cholesterol + Environment.NewLine + sodium, "Ok");
            //    //and then deselect the item.
            //    ListViewMenu.SelectedItem = null;
            //    loading.IsRunning = false;
            //}
        }
    }
}
