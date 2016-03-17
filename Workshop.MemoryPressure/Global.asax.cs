using System;
using System.Diagnostics;
using System.Web.Hosting;
using System.Web.Routing;

namespace Workshop.MemoryPressure
{
    public class Global : System.Web.HttpApplication
    {
        private const string _path = "~/Logs/log.txt";

        protected void Application_Start()
        {
            Trace.WriteLine("Application_Start");
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start()
        {
            Trace.WriteLine("Session_Start-" + Session.SessionID);
        }

        protected void Application_BeginRequest()
        {
            Trace.WriteLine("Application_BeginRequest-" + Request.RawUrl);
        }

        protected void Application_AuthenticateRequest()
        {
            Trace.WriteLine("Application_AuthenticateRequest");
        }

        protected void Application_EndRequest()
        {
            Trace.WriteLine("Application_EndRequest-" + Request.RawUrl);
        }

        protected void Application_Error()
        {
            Trace.WriteLine("Application_Error-" + Session.SessionID);
        }

        protected void Session_End()
        {
            Trace.WriteLine("Session_End-" + Session.SessionID);
        }

        protected void Application_End()
        {
            Trace.WriteLine("Application_End-" + HostingEnvironment.ShutdownReason);
        }
    }
}