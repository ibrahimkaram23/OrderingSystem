﻿using OrderingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Data.AppMetaData
{
    public static class Router
    {
        public const string singleRoute = "/{id}";

        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class ApplicationUserRouting
        {
            public const string Prefix = Rule + "User";
            public const string GetByID = Prefix + singleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + singleRoute;
            public const string Paginted = Prefix + "/Paginted";
            public const string ChangePassword = Prefix + "/Change-Password";

        }
        public static class Authentication
        {
            public const string Prefix = Rule + "Authentication";   
            public const string SignIn = Prefix + "/SignIn";
            public const string RefreshToken = Prefix + "/RefreshToken";
            public const string Delete = Prefix + singleRoute;
            public const string Paginted = Prefix + "/Paginted";
            public const string ValidateToken = Prefix + "/ValidateToken";
            public const string ConfirmEmail = "/Api/Authentication/ConfirmEmail";
            public const string SendResetPassword = Prefix + "/SendResetPassword";
            public const string ConfirmResetPassword = Prefix + "/ConfirmResetPassword";
            public const string ResetPassword = Prefix + "/ResetPassword";

        }
        public static class AuthorizationRouting
        {
            public const string Prefix = Rule + "AuthorizationRouting";
            public const string Roles = Prefix + "/Role";
            public const string Claims = Prefix + "/Claims";
            public const string Create = Roles + "/Create";
            public const string RoleList = Roles + "/Role-List";
            public const string Edit = Roles + "/Edit";
            public const string Delete = Roles + "/Delete/{id}";
            public const string GetRoleById = Roles + "/RoleById/{id}";
            public const string ManageUserRoles = Roles + "/ManageUserRoles/{userId}";
            public const string UpdateUserRoles = Roles + "/Update-User-Roles";
            public const string ManageUserClaims = Claims + "/Manage-User-Claims/{userId}";
            public const string UpdateUserClaims = Claims + "/Update-User-Claims";
        }
        public static class EmailsRoute
        {
            public const string Prefix = Rule + "EmailsRoute";
            public const string SendEmail = Prefix + "/SendEmail";
          
        }
        public static class CustomersRoute
        {
            public const string Prefix = Rule + "Customer";
            public const string GetCustomers = Prefix + "/GetAll";
            public const string GetByID = Prefix + singleRoute;
            public const string Create = Prefix + "/Create";

        }
        public static class OrdersRoute {
            public const string Prefix = Rule + "Orders";
            public const string GetOrders = Prefix + "/GetAll";
            public const string GetByID = Prefix + singleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + singleRoute;
            public const string EditStatus = Prefix + "/EditStatus";

        }
        public static class CategoriesRoute
        {
            public const string Prefix = Rule + "Categories";
            public const string Categories = Prefix + "/GetCategories";
            public const string GetByID = Prefix + singleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";

        }
    }
}

