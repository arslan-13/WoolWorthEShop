using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoolWorthEShop.DB;
using WoolWorthEShop.Entities;

namespace WoolWorthEShop.Services
{
    public class ConfigurationService
    {

        #region Constructor
        public static ConfigurationService Instance
        {
            get
            {
                if (PrivateInstance == null)
                {
                    PrivateInstance = new ConfigurationService();
                }
                return PrivateInstance;

            }
        }
        private static ConfigurationService PrivateInstance { get; set; }
        public ConfigurationService()
        {
        }

        #endregion

        public Config GetConfig(string Key)
        {
            using (var context = new WWContext())
            {
                return context.configs.Find(Key);
            }
        }

    }
}
