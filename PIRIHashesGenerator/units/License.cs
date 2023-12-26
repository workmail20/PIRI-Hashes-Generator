using DocumentFormat.OpenXml.Wordprocessing;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Windows.Services.Store;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PIRIHashesGenerator.units
{
    public class License
    {
        private readonly StoreContext context;
        public License()
        {
            context = StoreContext.GetDefault();
        }
        async public Task<bool> CheckLicense()
        {
            bool result = false;
            // StorePurchaseResult result2 = await context.RequestPurchaseAsync("9NKSQGP7F2NH");
            // var result4= MessageBox.Show("-000", "SkuStoreId");
            StoreAppLicense license = await context.GetAppLicenseAsync();
            //  var result2 = MessageBox.Show(license.SkuStoreId, "SkuStoreId");
            if (license.SkuStoreId.Length > 1)
            {
                //    var result3 = MessageBox.Show(license.IsActive.ToString(), "SkuStoreId");
                if (license.IsActive)
                {
                    result = true;
                }
            }

#if DEBUG
 result = true;
#endif

            return result;
        }


    }
}
