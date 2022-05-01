﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGEWebApp.Controllers
{
    public class BaseController : Controller
    {
        protected JsonResult JsonResponse(object obj)
        {
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}