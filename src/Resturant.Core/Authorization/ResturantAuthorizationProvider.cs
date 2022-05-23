using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Resturant.Authorization
{
    public class ResturantAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            context.CreatePermission(PermissionNames.Customers_Active_Deactive, L("Customers_Active_Deactive"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ResturantConsts.LocalizationSourceName);
        }
    }
}
