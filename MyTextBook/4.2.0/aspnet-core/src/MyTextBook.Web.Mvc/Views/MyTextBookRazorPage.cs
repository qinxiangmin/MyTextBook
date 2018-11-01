using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace MyTextBook.Web.Views
{
    public abstract class MyTextBookRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MyTextBookRazorPage()
        {
            LocalizationSourceName = MyTextBookConsts.LocalizationSourceName;
        }
    }
}
