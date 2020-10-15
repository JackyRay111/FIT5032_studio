using System.Web;
using System.Web.Mvc;

namespace FIT5032_Week05_Post_Maps
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
