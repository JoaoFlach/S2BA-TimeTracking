using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TimeTracking.MVC.Models;


namespace TimeTracking.MVC.Controllers
{
    public class UserController : Controller
    {
        private EntitiesContext context = new EntitiesContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();            
            
            return View();
        }
    }
}