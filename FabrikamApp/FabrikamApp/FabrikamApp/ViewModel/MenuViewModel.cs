using FabrikamApp.Model;
using FabrikamApp.Services;
using FabrikamApp.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FabrikamApp.ViewModel
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        private bool busy;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public ICommand GoMenuCommand { get; set; }
        public ICommand GoHomeCommand { get; set; }
        public ICommand GoSuggestionsCommand { get; set; }
        public ICommand GoContactCommand { get; set; }
        public Command GetMenuCmd { get; set; }

        public ObservableCollection<Menu> MenuList { get; set; }

        public bool IsBusy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged();
                //Update the can execute
                GetMenuCmd.ChangeCanExecute();
            }
        }

        public MenuViewModel()
        {
            MenuList = new ObservableCollection<Menu>();
            GoMenuCommand = new Command(GoToMenu);
            GoHomeCommand = new Command(GoToHome);
            GoSuggestionsCommand = new Command(GoToSuggestions);
            GoContactCommand = new Command(GoToContact);
        }

        void GoToMenu(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new MenuPage()){
                                    BarBackgroundColor = Color.Teal};
            App.MenuIsPresented = false;
        }

        void GoToHome(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new HomePage()){
                                    BarBackgroundColor = Color.Teal};
            App.MenuIsPresented = false;
        }

        void GoToSuggestions(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new SuggestionsPage()) {
                                    BarBackgroundColor = Color.Teal};
            App.MenuIsPresented = false;
        }
        void GoToContact(object obj)
        {
            App.RootPage.Detail = new NavigationPage(new ContactPage())
            {
                BarBackgroundColor = Color.Teal
            };
            App.MenuIsPresented = false;
        }


        public static async Task ShowNF(string s)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://api.nutritionix.com/v1_1/search/" + s + "?results=0:1"
                    + "&fields=item_name,nf_calories,nf_cholesterol,nf_sodium&appId=023582a7&appKey=ac44e6c6b65e3dd4182fb99cbd9b652a";
                //grab json from server
                var json = await client.GetStringAsync(url.Replace(" ", "%20"));
                //deserialize the json and turn it into a list of dishes with Json.NET
                NutritionFacts.RootObject items = JsonConvert.DeserializeObject<NutritionFacts.RootObject>(json);
                List<NutritionFacts.Hit> hits = items.hits;

                string calories = "Calories: " + hits[0].fields.nf_calories.ToString("N2");
                string cholesterol = "Cholesterol" + hits[0].fields.nf_cholesterol.ToString("N2");
                string sodium = "Sodium" + hits[0].fields.nf_sodium.ToString("N2");

                await Application.Current.MainPage.DisplayAlert("Nutrition Facts", calories + Environment.NewLine + cholesterol + Environment.NewLine + sodium, "Ok");
                //and then deselect the item.
            }
        }


    }
}
