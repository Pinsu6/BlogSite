using BlogApp.Areas.User.Models;
using BlogApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace BlogApp.Areas.User.Controllers
{
	[Area("User")]
	public class UserController : Controller
	{
		IConfiguration configuration;
		public UserController(IConfiguration configuration) 
		{
			this.configuration = configuration;
		}
		public IActionResult Register()
		{

			return View();
		}
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("User")==null)
            {
                return View();
            }
            return RedirectToAction("index", "Blog", new { area = "Blog" });
        }

        [HttpPost]
        public IActionResult Login(Models.Login l)
        {
           
            if (ModelState.IsValid)
            {
                Models.Login l1 = null;
                DbLogic d = new DbLogic();
                d.connect(configuration);
                l1 = d.Login("LoginUser", l);
                if (l1 != null)
                {

                    HttpContext.Session.SetString("User", l1.name);
                    HttpContext.Session.SetInt32("UserId", l1.id);
                    HttpContext.Session.SetInt32("isAdmin", l1.isAdmin);
                    return RedirectToAction("index", "Blog", new { area = "Blog" });
                }
                else
                {
                    ViewBag.message = "User not found";
                    return View();
                }
                
                
            }
          



            return  View();
        }



        [HttpPost]
        public IActionResult Register(RegisterUser registerUser)
        {
            
                if(ModelState.IsValid)
                {
                DbLogic d = new DbLogic();
                d.connect(configuration);
                if (d.InsertUserData("AddUser", registerUser) == 1)
                {
                    return RedirectToAction("Login");

                }
                else
                {
                    return View();
                }

                }


            return View();



        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Login");
        }


    }
}
