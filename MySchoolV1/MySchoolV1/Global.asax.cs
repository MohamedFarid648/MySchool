using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MySchoolV1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            /*
             To Solve error:
             * The model backing the 'Context Class' context has changed since the database was created. 
             * Consider using Code First Migrations to update the database
         
             */
            Database.SetInitializer<MySchoolV1.Models.DBContextClass>(null);
            /*End*/

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
