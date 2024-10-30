using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    
    public class HomeController : Controller
    {
        IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult ContectUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContectUs(Contect c)
        {
            DbLogic dbLogic = new DbLogic();
            dbLogic.connect(_configuration);
            dbLogic.addContect("addconect", c);

            return View();
        }
       
    }
}
