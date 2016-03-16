using System;
using System.Web.Hosting;
using System.Web.Routing;
using Workshop.MemoryPressure.Tools;

namespace Workshop.MemoryPressure
{
    public class Global : System.Web.HttpApplication
    {
        private const string _path = "~/Logs/log.txt";

        protected void Application_Start(object sender, EventArgs e)
        {
            SimpleTextLog.WriteData(() => Server.MapPath(_path), () => "Application_Start");
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            SimpleTextLog.WriteData(() => Server.MapPath(_path), () => "Session_Start-" + Session.SessionID);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            SimpleTextLog.WriteData(() => Server.MapPath(_path), () => "Application_BeginRequest-" + Request.RawUrl);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            SimpleTextLog.WriteData(() => Server.MapPath(_path), () => "Application_AuthenticateRequest");
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            SimpleTextLog.WriteData(() => Server.MapPath(_path), () => "Application_EndRequest-" + Request.RawUrl);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            SimpleTextLog.WriteData(() => Server.MapPath(_path), () => "Application_Error-" + Session.SessionID);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            SimpleTextLog.WriteData(() => Server.MapPath(_path), () => "Session_End-" + Session.SessionID);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            SimpleTextLog.WriteData(() => Server.MapPath(_path), () => "Application_End-" + HostingEnvironment.ShutdownReason);
        }
    }
}