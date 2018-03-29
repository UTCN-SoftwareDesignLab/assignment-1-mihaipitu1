using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Database
{
    public class Constants
    {
        public static class Roles
        {
            public static string ADMIN = "admin";
            public static string EMPLOYEE = "employee";

            public static string[] ROLES = { ADMIN, EMPLOYEE };
        }

        public static class Rights
        {
            public static string CREATE_USER = "create_user";
            public static string DELETE_USER = "delete_user";
            public static string UPDATE_USER = "update_user";

            public static string CREATE_CLIENT = "create_client";
            public static string UPDATE_CLIENT = "update_client";
            public static string DELETE_CLIENT = "delete_client";

            public static string ADD_ACCOUNT = "add_account";
            public static string EDIT_ACCOUNT = "edit_account";
            public static string DELETE_ACCOUNT = "delete_account";

            public static string[] RIGHTS = {CREATE_USER,DELETE_USER,UPDATE_USER,CREATE_CLIENT,UPDATE_CLIENT,DELETE_CLIENT,ADD_ACCOUNT,EDIT_ACCOUNT,DELETE_ACCOUNT};
            public static string[] ADMIN_RIGHTS = { CREATE_USER, DELETE_USER, UPDATE_USER };
            public static string[] USER_RIGHTS = { CREATE_CLIENT, UPDATE_CLIENT, DELETE_CLIENT, ADD_ACCOUNT, EDIT_ACCOUNT, DELETE_ACCOUNT };
        }
    }
}
