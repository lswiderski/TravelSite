using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        protected override void ExecuteCore()
        {
            var culture = Session["lang"] ?? "en-US";

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture.ToString());
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            base.ExecuteCore();
        }

        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }
    }
}