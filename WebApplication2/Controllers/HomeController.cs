﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult GetAllUser()
        {
            try
            {
                localhost.WebService2 service2 = new localhost.WebService2();
                string a = service2.GetAllUser();
                return Json(a);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}