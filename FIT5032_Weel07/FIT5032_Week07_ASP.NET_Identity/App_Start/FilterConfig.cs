using System.Web;
using System.Web.Mvc;

namespace FIT5032_Week07_ASP.NET_Identity
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
