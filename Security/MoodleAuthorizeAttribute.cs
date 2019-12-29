using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moodle.Security
{
    public class MoodleAuthorizeAttribute: AuthorizeAttribute
    {
        public new string[] Roles { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Debug.WriteLine("**********  AuthorizeCore is called");

            //If the roles required for the Controller/Action is none, return true directly
            if (Roles == null)
            {
                Debug.WriteLine("**********  No role is required, authorization pass");
                return true;
            }
            if (Roles.Length == 0)
            {
                Debug.WriteLine("**********  The number of required roles is 0, authorization pass");
                return true;
            }

            if (httpContext == null)
            {
                throw new ArgumentNullException("HttpContext");
            }

            if (!httpContext.User.Identity.IsAuthenticated)
            {
                Debug.WriteLine("**********  User ID:" + httpContext.User.Identity.Name);
                Debug.WriteLine("**********  User is not authenticated.");
                return false;
            }

            Debug.WriteLine("**********  User ID:" + httpContext.User.Identity.Name);

            //Debug.WriteLine("**********  User's roles are" + (httpContext.User as MoodlePrincipal).RoleList);
            Debug.WriteLine("**********  User's roles are:" + httpContext.Session["Roles"]);

            string[] userRoles = (httpContext.Session["Roles"] as string).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach(string userRole in userRoles)
            {
                foreach (string reqRole in Roles)
                {
                    if (userRole == reqRole)
                    {
                        Debug.WriteLine("********** User has the permission");
                        return true;
                    }

                }
            }

            //if (Roles.Any(httpContext.User.IsInRole))
            //{
            //    Debug.WriteLine("**********  User's roles are" + (httpContext.User as MoodlePrincipal).RoleList+", and the user has the authority");
            //    return true;
            //}
            return false;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //Initialize this.Roles with null
            this.Roles = null;

            //get the controller and action that need to be authorized
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;

            Debug.WriteLine("xxxxxxxxxx  Controller:" + controllerName+" Action:"+actionName+" is called");

            //get the roles required for the controller and action
            string roles = GetRoles.GetActionRoles(actionName, controllerName);

            Debug.WriteLine("**********  Roles required:" + (roles == ""? "None":roles)); ;

            //if the roles are not null or "", get the specific roles by splitting
            if (!string.IsNullOrWhiteSpace(roles))
            {
                this.Roles = roles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }


            base.OnAuthorization(filterContext);
        }
    }
}