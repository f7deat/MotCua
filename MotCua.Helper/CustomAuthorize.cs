using MotCua.Helper.Common;
using MotCua.Helper.Session;
using System.Web;
using System.Web.Mvc;

namespace MotCua.Helper
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            UserSessionModel session = (UserSessionModel)HttpContext.Current.Session[Constants.USER_SESSION];
            if (session == null)
            {
                httpContext.Response.Redirect("/");
                return false;
            }
            if (Roles.Contains(session.Group.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
            //return base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Errors/Authorized.cshtml"
            };
        }
    }
}
