using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyTextBook.Controllers;

namespace MyTextBook.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : MyTextBookControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
