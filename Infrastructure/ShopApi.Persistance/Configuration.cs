using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Persistance
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configuration = new();
                try
                {
                    configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ShopApi.UI"));
                    configuration.AddJsonFile("appsettings.json");
                }
                catch
                {
                    configuration.AddJsonFile("appsettings.Production.json");
                }
                return configuration.GetConnectionString("SqlServer");
            }
        }
    }
}
