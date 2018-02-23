using System.Web.Mvc;

namespace ByteNuts.PrimaveraBss.JasminSdk.Samples.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
