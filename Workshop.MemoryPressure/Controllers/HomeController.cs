using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            decimal pressure = GC.GetTotalMemory(false) / 1024 / 1024.0M;

            return View(pressure);
        }

        [HttpPost]
        public ActionResult IncreasePressure()
        {
            hash[Guid.NewGuid()] = new byte[_pressure];

            decimal pressure = GC.GetTotalMemory(false) / 1024 / 1024.0M;

            return View("~/Views/Home/Index.cshtml", pressure);
        }

    }
}