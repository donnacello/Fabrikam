using FabrikamApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FabrikamApp
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            //Create the view model and set as binding context
            BindingContext = new MenuViewModel();
            InitializeComponent();
        }
    }
}
