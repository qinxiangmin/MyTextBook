using Abp.AspNetCore.Mvc.ViewComponents;

namespace MyTextBook.Web.Views
{
    public abstract class MyTextBookViewComponent : AbpViewComponent
    {
        protected MyTextBookViewComponent()
        {
            LocalizationSourceName = MyTextBookConsts.LocalizationSourceName;
        }
    }
}
