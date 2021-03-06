﻿using FabrikamApp.Model;
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


        


    }
}
