using FabrikamApp.Model;
using FabrikamApp.Services;
using FabrikamApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
            
            //add an event to the ListViewSpeakers to get notified when an item is selected
            //ListViewMenu.ItemSelected += ListViewMenu_ItemSelected;
        }

        private async void ViewMenu(Object sender, System.EventArgs e)
        {
            List<Menu> menu = await AzureServices.AzureServicesInstance.GetMenu();
            ListViewMenu.ItemsSource = menu;
        }

        //uncomment above and below when adding DESCRIPTION PAGE

        //private async void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var menuitem = e.SelectedItem as Menu;
        //    //check to see if the selected item is not null 
        //    if (menuitem == null)
        //        return;
        //    //and then use the built in Navigation API to push a new page 
        //    await Navigation.PushAsync(new DescriptionPage(menuitem));
        //    //and then deselect the item.
        //    ListViewMenu.SelectedItem = null;
        //}
    }
}
