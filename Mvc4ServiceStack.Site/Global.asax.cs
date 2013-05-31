using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Mvc4.ServiceStack.Service;
using Mvc4.ServiceStack.App_Start;
using Mvc4.ServiceStack.ServiceModel.Request;
using ServiceStack.WebHost.Endpoints;

namespace Mvc4.ServiceStack
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Create your ServiceStack web service application with a singleton AppHost.
        /// </summary>        
        public class StoreAppHost : AppHostBase
        {
            /// <summary>
            /// Initializes a new instance of your ServiceStack application, with the specified name and assembly containing the services.
            /// </summary>
            public StoreAppHost() : base("Store Web Services", typeof(StoreService).Assembly) { }

            /// <summary>
            /// Configure the container with the necessary routes for your ServiceStack application.
            /// </summary>
            /// <param name="container">The built-in IoC used with ServiceStack.</param>
            public override void Configure(Funq.Container container)
            {
                Routes
                    .Add<OrgLevelRequest>("/orglevel")
                    .Add<RetailerRequest>("/retailer")
                    .Add<StoreRequest>("/store")
                    .Add<GetOnlyStore>("/storeall")
                    .Add<SubOrgLevelRequest>("/suborglevel");

            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Initialize your application
            (new StoreAppHost()).Init();
        }
    }
}