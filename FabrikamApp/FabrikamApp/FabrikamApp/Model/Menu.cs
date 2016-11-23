using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabrikamApp.Model
{
    public class Menu
    {
        //Menu Attributes
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        //Azure information for version
        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }
    }
}