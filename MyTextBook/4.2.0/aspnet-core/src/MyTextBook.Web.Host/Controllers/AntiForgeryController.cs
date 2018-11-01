using Microsoft.AspNetCore.Antiforgery;
using MyTextBook.Controllers;

namespace MyTextBook.Web.Host.Controllers
{
    public class AntiForgeryController : MyTextBookControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
