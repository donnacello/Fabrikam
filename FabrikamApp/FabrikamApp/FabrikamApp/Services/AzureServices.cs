using FabrikamApp.Model;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabrikamApp.Services
{
    class AzureServices
    {
        private static AzureServices instance;
        private MobileServiceClient client;
        private IMobileServiceTable<Menu> menuTable;

        private AzureServices()
        {
            this.client = new MobileServiceClient("http://donnamoodtimeline.azurewebsites.net");
            this.menuTable = this.client.GetTable<Menu>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureServices AzureServicesInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureServices();
                }

                return instance;
            }
        }

        public async Task<List<Menu>> GetMenu()
        {
            return await this.menuTable.ToListAsync();
        }

        //public async Task AddMenu(Menu menu)
        //{
        //    await this.menuTable.InsertAsync(menu);
        //}

        //public async Task UpdateMenu(Menu menu)
        //{
        //    await this.menuTable.UpdateAsync(menu);
        //}

        //public async Task DeleteMenu(Menu menu)
        //{
        //    await this.menuTable.DeleteAsync(menu);
        //}







        //public MobileServiceClient Client { get; set; } = null;
        //IMobileServiceSyncTable<Menu> list;

        //public async Task Initialize()
        //{
        //    if (Client?.SyncContext?.IsInitialized ?? false)
        //        return;

        //    var appUrl = "https://fabrikammenusuggestions.azurewebsites.net";

        //    //Create our client
        //    Client = new MobileServiceClient(appUrl);

        //    //InitialzeDatabase for path
        //    var path = "Menu.db";
        //    path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);


        //    //setup our local sqlite store and intialize our table
        //    var store = new MobileServiceSQLiteStore(path);

        //    //Define table
        //    store.DefineTable<Menu>();

        //    //Initialize SyncContext
        //    await Client.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

        //    //Get our sync table that will call out to azure
        //    list = Client.GetSyncTable<Menu>();
        //}


        //public async Task<IEnumerable<Menu>> GetMenu()
        //{
        //    //method to Initialize, Sync, and query the table for items
        //    await Initialize();
        //    await SyncMenu();
        //    return await list.OrderBy(s => s.Name).ToEnumerableAsync();
        //}


        //public async Task SyncMenu()
        //{
        //    try
        //    {
        //        //push any local changes and then pull all of the latest data from the server
        //        await Client.SyncContext.PushAsync();
        //        await list.PullAsync("MenuList", list.CreateQuery());
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Unable to sync menu: " + ex);
        //    }

        //}
    }
}
