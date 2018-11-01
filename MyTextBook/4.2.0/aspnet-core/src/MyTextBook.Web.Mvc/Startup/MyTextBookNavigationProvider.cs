using Abp.Application.Navigation;
using Abp.Localization;
using MyTextBook.Authorization;

namespace MyTextBook.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class MyTextBookNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "business",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "local_offer",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("Orders"),
                        url: "Orders",
                        icon: "shopping_cart"
                    )
                ).AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "MultiLevelMenu",
                        L("MultiLevelMenu"),
                        icon: "settings"
                    ).AddItem(
                        new MenuItemDefinition(
                            "AspNetZero",
                            new FixedLocalizableString("前台页面")
                        ).AddItem(
                            new MenuItemDefinition(
                                "ClientHome",
                                new FixedLocalizableString("ClientHome"),
                                url: "ClientHome"
                            )
                        )
                    )
                ).AddItem(
                        new MenuItemDefinition(
                            "AspNetBoilerplate",
                            new FixedLocalizableString("信息维护"),
                            icon: "menu"
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.Students,
                                L("Student"),
                                url: "Students",
                                icon: "perm_identity"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.Department,
                                L("Department"),
                                url: "TDepartments",
                                icon: "store"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.Major,
                                L("Major"),
                                url: "Majors",
                                icon: "stars"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.StudentClass,
                                L("StudentClass"),
                                url: "StudentClasses",
                                icon: "perm_contact_calendar"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.AcademicYear,
                                L("StudentBookDetailses"),
                                url: "StudentBookDetailses",
                                icon: "supervisor_account"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.Course,
                                L("Course"),
                                url: "Courses",
                                icon: "assessment"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.CourseType,
                                L("CourseType"),
                                url: "CourseTypes",
                                icon: "view_headline"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.BookType,
                                L("BookType"),
                                url: "BookTypes",
                                icon: "assignment"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.Book,
                                L("Book"),
                                url: "Books",
                                icon: "library_books"
                            )
                        ));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyTextBookConsts.LocalizationSourceName);
        }
    }
}
