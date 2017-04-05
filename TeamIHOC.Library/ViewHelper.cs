using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TeamIHOC.Library.Identity;
using TeamIHOC.Library.Model;

namespace TeamIHOC.Library
{
    public class ViewHelper
    {
        public static ApplicationRoleManager RoleManager()
        {
            return HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
        }

        public static ApplicationUserManager UserManager()
        {
            return HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }

        //public static bool UserInRole(string roleName)
        //{
        //    ApplicationUser user = UserManager().FindByName(HttpContext.Current.User.Identity.Name);
            
        //}
    }
}
