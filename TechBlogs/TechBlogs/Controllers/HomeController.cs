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
using System.Net;
using static TechBlogs.ApplicationUserManager;
using BusinessLayer;
using BusinessObjects;

namespace TechBlogs.Controllers
{
    public class HomeController : Controller
    {
        Business BL = new Business();
         
        private readonly ILogger _logger;
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

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

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
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


        // POST: /Home/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.EmailID, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        //Get All Blogs
        [HttpGet]
        public ActionResult GetAllBlogs(int? id)
        {
            var result=BL.GetAllPosts(id);
            return Json(result);
            //int pageNumber = id ?? 0;
            //IEnumerable<Posts> pst = (from post in BE.posts
            //                          where post.datetimepost < DateTime.Now
            //                          orderby post.datetimepost descending
            //                          select post).Skip(pageNumber * PostsperPage).Take(PostsperPage + 1);
            //ViewBag.IsPreviousLinkVisible = pageNumber > 0;
            //ViewBag.IsNextLinkVisible = pst.Count() > PostsperPage;
            //ViewBag.PageNumber = pageNumber;
            //ViewBag.IsAdmin = IsAdmin;
            //return View(pst.Take(PostsperPage));
        }

        [HttpGet]
        public ActionResult test()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PostBlogs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostBlogs(Posts pst)
        {
            BL.AddBlogs(pst);
            return View();
        }

        [HttpGet]
        public ActionResult blog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LikePost(int postid)
        {
            BL.LikePost(postid);
            return View("Home");
        }

    }
}
