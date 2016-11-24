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
            this.client = new MobileServiceClient("http://fabrikammenusuggestions.azurewebsites.net");
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

    }
}
