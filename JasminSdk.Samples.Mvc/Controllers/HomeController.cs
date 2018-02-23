using System.Threading.Tasks;
using System.Web.Mvc;
using ByteNuts.PrimaveraBss.JasminSdk.Core.Services;

namespace ByteNuts.PrimaveraBss.JasminSdk.Samples.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CustomerPartyList()
        {
            var jasminClient = new JasminSalesClient();

            var customerList = await jasminClient.CustomerParty.GetCustomerPartiesWithParty();

            return View(customerList.Response);
        }

        public async Task<ActionResult> ProductList()
        {
            var jasminClient = new JasminMasterDataBusinessEntitiesClient();

            var productList = await jasminClient.Item.GetItems();

            return View(productList.Response);
        }
    }
}