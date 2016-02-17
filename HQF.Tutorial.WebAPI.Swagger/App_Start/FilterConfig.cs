using System.Web;
using System.Web.Mvc;

namespace HQF.Tutorial.WebAPI.Swagger
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
