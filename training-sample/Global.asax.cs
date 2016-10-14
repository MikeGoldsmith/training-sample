using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace training_sample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            CouchbaseConfig.Setup();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
