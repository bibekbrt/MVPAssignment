﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVPAssignmentProject.UI.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Login()
        {
            return View();
        }
    }
}