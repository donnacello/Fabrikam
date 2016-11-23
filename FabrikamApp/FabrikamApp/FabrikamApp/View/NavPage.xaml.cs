using FabrikamApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FabrikamApp.View
{
    public partial class NavPage : ContentPage
    {
        public NavPage()
        {
            BindingContext = new MenuViewModel();
            Title = "Menu";
            Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null;
            InitializeComponent();
        }
    }
}
