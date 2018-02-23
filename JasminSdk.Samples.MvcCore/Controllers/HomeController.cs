using System.Diagnostics;
using System.Threading.Tasks;
using ByteNuts.NetCoreControls.Core.Extensions;
using ByteNuts.NetCoreControls.Core.Models;
using ByteNuts.NetCoreControls.Models.Grid;
using ByteNuts.PrimaveraBss.JasminSdk.Core.Services;
using Microsoft.AspNetCore.Mvc;
using ByteNuts.PrimaveraBss.JasminSdk.Samples.MvcCore.Models;

namespace ByteNuts.PrimaveraBss.JasminSdk.Samples.MvcCore.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IJasminClient JasminClient;
        public HomeController(IJasminClient jasminClient)
        {
            JasminClient = jasminClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CustomerPartyList()
        {
            var customerList = await JasminClient.Sales.CustomerParty.GetCustomerPartiesWithParty();

            var context = new NccGridContext
            {
                Id = "CustomerPartyList",
                AutoBind = false,
                DataSource = customerList.Response,
                PageSize = 10,
                ViewPaths = new ViewsPathsModel { ViewPath = "/Views/Home/_CustomerPartyGrid.cshtml" }
            };
            ViewData[context.Id] = context;

            return View();
        }

        public async Task<IActionResult> ProductList()
        {
            var productList = await JasminClient.MasterDataBusinessEntities.Item.GetItems();

            var context = new NccGridContext
            {
                Id = "ProductList",
                AutoBind = false,
                DataSource = productList.Response,
                PageSize = 10,
                ViewPaths = new ViewsPathsModel { ViewPath = "/Views/Home/_ProductGrid.cshtml" }
            };
            ViewData[context.Id] = context;


            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
