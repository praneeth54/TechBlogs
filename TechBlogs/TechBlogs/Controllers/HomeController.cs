using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechBlogs.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.Owin.Logging;

namespace TechBlogs.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult Home()
        {
            ViewBag.Title = "Home Page";

            return View("Home");
        }

        [HttpGet]
        public ActionResult AddorEditUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddorEditUser(Users _users)
        {
            var user = new ApplicationUser { UserName = _users.UserName, Email = _users.Email , PasswordHash= _users.Password};
            var result = await _userManager.CreateAsync(user, _users.Password);
            var id = user.Id;
            if (result.Succeeded)
            {
                _logger.WriteInformation("User created a new account with password.");
            }

            return View();
        }
    }
}
