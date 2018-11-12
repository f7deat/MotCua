using MotCua.Helper.Common;
using MotCua.Helper.Session;
using System.Web.Mvc;

namespace MotCua.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UserSessionModel session = (UserSessionModel)Session[Constants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectResult("/");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}