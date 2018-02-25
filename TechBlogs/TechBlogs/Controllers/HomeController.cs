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
using Microsoft.Owin.Security;

namespace TechBlogs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private ApplicationUserManager _userManager;

       
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }
        public HomeController(ApplicationUserManager userManager,
           ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public HomeController()
        {

        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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
                var user = new ApplicationUser() { UserName = _users.Email, Email = _users.Email , PasswordHash= _users.LastName};

            try
            {

                IdentityResult result = await UserManager.CreateAsync( user, _users.Password);
                var id = user.Id;
                if (result.Succeeded)
                {
                    _logger.WriteInformation("User created a new account with password.");
                }

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

       

        public void Login(string UName, string Pwd, string returnUrl = null)
        {
            var result2 = await _signInManager.PasswordSignInAsync(UName, Pwd, false, lockoutOnFailure: false);
            if (result2.Succeeded)
            {
                var streaker = objStreakBusiness.GetStreakerByEmailID(UName);
                var claims = User.Claims;
                //int id = int.Parse(claims.ElementAt(6).Value);


                objStreakBusiness.StreakerLogin(streaker.StreakerID);
                _logger.LogInformation(1, "User logged in.");
                if (streaker.Role == 3)
                {
                    return RedirectToAction("AdminDashBoard");
                }
                else
                    return RedirectToAction("CoachUsers");
            }
            ViewBag.Message = "Username or Password is Incorrect.";
            return View("Index");
        }

        //Get All Blogs
        [HttpGet]
        public ActionResult GetAllBlogs(int? id)
        {
            int pageNumber = id ?? 0;
            IEnumerable<Posts> pst = (from post in BE.posts
                                     where post.datetimepost < DateTime.Now
                                     orderby post.datetimepost descending
                                     select post).Skip(pageNumber * PostsperPage).Take(PostsperPage + 1);
            ViewBag.IsPreviousLinkVisible = pageNumber > 0;
            ViewBag.IsNextLinkVisible = pst.Count() > PostsperPage;
            ViewBag.PageNumber = pageNumber;
            ViewBag.IsAdmin = IsAdmin;
            return View(pst.Take(PostsperPage));
        }




    }
}
