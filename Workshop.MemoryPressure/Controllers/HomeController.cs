using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Workshop.MemoryPressure.Models;

namespace Workshop.MemoryPressure.Controllers
{
    public class HomeController : Controller
    {
        #region fields
        private static Dictionary<Guid, byte[]> hash = new Dictionary<Guid, byte[]>();
        private const int _pressure = 1024 * 1024 * 13;
        #endregion

        [HttpGet]
        public ActionResult Index()
        {
            var name = Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME");
            var instance = Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID");

            var model = new Index()
            {
                Pressure = GC.GetTotalMemory(false) / 1024 / 1024.0M,
                ShortId = (instance ?? "000000").Substring(0, 6),
                KuduLink = name == null ? null : string.Format("https://{0}.scm.azurewebsites.net/DebugConsole", name)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult IncreasePressure()
        {
            var pressure = new byte[_pressure];
            for (int i = 0; i < pressure.Length; i++)
                pressure[i] = (byte)(i % 128);
            hash[Guid.NewGuid()] = pressure;

            return RedirectToAction("Index");
        }

    }
}