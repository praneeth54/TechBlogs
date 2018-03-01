using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechBlogs.Models
{
    public class LoginViewModel
    {
        public string EmailID { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}