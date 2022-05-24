using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using Resturant.Authorization;

namespace Resturant.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class ResturantNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
              .AddItem(
                    new MenuItemDefinition(
                        PageNames.Admins,
                        L("Admins"),
                        url: "Admins",
                        icon: "fas fa-info-circle"
                    )
                )
              .AddItem(
                    new MenuItemDefinition(
                        PageNames.Menu,
                        L("Menu"),
                        url: "/home/Menu",
                        icon: "fas fa-info-circle"
                    )
                )
              .AddItem(
                    new MenuItemDefinition(
                        PageNames.Reserve,
                        L("Reserve"),
                        url: "/Home/Reserve",
                        icon: "fas fa-info-circle"
                    )
                )


              .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "fas fa-info-circle"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Customers,
                        L("Customers"),
                        url: "Customers",
                        icon: "fas fa-building",
                       permissionDependency: new SimplePermissionDependency(PermissionNames.Customers_Active_Deactive)
                    )
                )
              .AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "User Managment",
                        L("user_managment"),
                        icon: "fas fa-circle"
                    ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                    )
                )
                );

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ResturantConsts.LocalizationSourceName);
        }
    }
}