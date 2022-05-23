﻿namespace Resturant.Authorization
{
    public static class PermissionNames
    {
        public const string Pages_Tenants = "Pages.Tenants";

        public const string Pages_Users = "Pages.Users";
        public const string Pages_Users_Activation = "Pages.Users.Activation";

        public const string Pages_Roles = "Pages.Roles";
        public const string Customers_Active_Deactive = nameof(Customers_Active_Deactive);




        public const string Pages_Doctors = nameof(Pages_Doctors);
        public const string Pages_Specialties = nameof(Pages_Specialties);
        public const string Pages_Employees = nameof(Pages_Employees);
        public const string Pages_Admins = nameof(Pages_Admins);

        public const string Pages_Centers = nameof(Pages_Centers);

        public const string Roles_View = nameof(Roles_View);
        public const string Roles_Add_Edit = nameof(Roles_Add_Edit);
        public const string Roles_Active_Deactive = nameof(Roles_Active_Deactive);



        public const string Doctors_View = nameof(Doctors_View);
        public const string Doctors_Active_Deactive = nameof(Doctors_Active_Deactive);
        public const string Doctors_Add_Edit = nameof(Doctors_Add_Edit);

        public const string Employees_View = nameof(Employees_View);
        public const string Employees_Add_Edit = nameof(Employees_Add_Edit);

        public const string Missions_View = nameof(Missions_View);
        public const string Missions_ChangeState = nameof(Missions_ChangeState);

    }
}
