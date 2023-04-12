using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HotelManagement
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        public override string[] GetRolesForUser(string username)
        {
            //HotelManagementDBEntities2 con= new HotelManagementDBEntities2();
            //string role = con.GetRole(mail);
            //string[] result = {role};
            //return result;
            using (var context = new HotelManagementDBEntities2())
            {
                var res = (from staff in context.STAFFs
                          join role in context.ROLEEs on staff.ID equals role.ID
                           where staff.Mail_ID == username
                           select role.Role).ToArray();
                //var res = (from role in context.ROLEEs
                //           join staff in context.STAFFs on role.Staff_ID equals staff.Staff_ID
                //           where staff.Mail_ID == mail
                //           select role.Role).ToArray();
                return res;
            }
            
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}