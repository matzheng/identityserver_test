﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace identityserver_test.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            var caller = User as ClaimsPrincipal;
            return Json(new {
                message = "OK computer",
                client = caller.FindFirst("client_id").Value
            });
        }
    }
}