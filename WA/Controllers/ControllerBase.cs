using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using WA.Services;

namespace WA.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly IMyService _myService;

        public ControllerBase(IMyService myService)
        {
            _myService = myService;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            ViewBag.CurrentApplicationUserName = User.Identity.Name;
        }
    }
}
