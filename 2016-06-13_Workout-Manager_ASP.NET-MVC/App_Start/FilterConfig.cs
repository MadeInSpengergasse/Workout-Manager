using System.Web;
using System.Web.Mvc;

namespace _2016_06_13_Workout_Manager_ASP.NET_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
