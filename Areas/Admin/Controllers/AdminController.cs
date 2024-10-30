using BlogApp.Areas.Admin.Models;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        IConfiguration _configuration;
        IWebHostEnvironment _environment;
        public AdminController(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this._configuration = configuration;
            _environment = environment;
        }
        public IActionResult Index()
        {
            DbLogic d = new DbLogic();
            d.connect(_configuration);
            ViewBag.usercount = d.userCount("usercount");
            ViewBag.blogcount = d.userCount("blogcount");
            ViewBag.categorycount = d.categoryCount("countbycategory");
            return View();
        }

        public IActionResult Bloginsert()
        {
            DbLogic db = new DbLogic();
            db.connect(_configuration);
            ViewBag.categoryname = db.fetchcat("selectcategoryname");
            return View();
        }

        [HttpPost]
        public IActionResult Bloginsert(InsertBlogView b)
        {
            String filename = "";
            try
            {
                if (b.Image != null)
                {
                    String folder = Path.Combine(_environment.WebRootPath, "images");
                    filename =b.Image.FileName;
                    String filepath = Path.Combine(folder, filename);
                    b.Image.CopyTo(new FileStream(filepath, FileMode.Create));
                    Insertblog b1 = new Insertblog()
                    {
                        Blogname = b.Blogname,
                        AuthName = b.AuthName,
                        ShortDesc = b.ShortDesc,
                        Image = filename,
                        Descript = b.Descript,
                        Category = b.Category,

                    };

                    DbLogic db = new DbLogic();
                    db.connect(_configuration);
                    db.AddBlog("AddBlog", b1);



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(ex.Message);
            }


            return RedirectToAction("Index");
        }

        public IActionResult Manageblog()
        {
            DbLogic d = new DbLogic();
            d.connect(_configuration);
            ViewBag.blog = d.GetData("GetBlogs");
           
            return View();
        }

        [HttpGet]
        [Route("/Admin/Admin/Updateblog/{id}")]
      
        public IActionResult Updateblog(int id)
        {
            DbLogic d = new DbLogic();
            d.connect(_configuration);
            Insertblog b = d.getBlogById("getblogById", id);
            //ViewBag.UpdateblogCategory = d.fetchcat("selectcategoryname");
                
            return View(b);
        }



        [HttpPost]
        [Route("/Admin/Admin/Updateblog/{id}")]
       
        public IActionResult Updateblog(int id, Insertblog b2)
        {
            

            DbLogic d = new DbLogic();
            d.connect(_configuration);

            // Check if a new image filename is provided
            

            
            Insertblog b1 = new Insertblog()
            {
                Blogname = b2.Blogname,
                AuthName = b2.AuthName,
                ShortDesc = b2.ShortDesc, 
                Descript = b2.Descript,
            };

            d.updateBlog("UpdateBlog", id, b2);

            return RedirectToAction("Manageblog");
        }





        [Route("/Admin/Admin/deleteBlog/{id}")]
        public IActionResult deleteBlog(int id)
        {
            DbLogic d = new DbLogic();
            d.connect(_configuration);
            d.deleteBlog("deleteBlog", id);

            return RedirectToAction("Manageblog");
        }

        public IActionResult CategoryManage()
        {
            DbLogic d = new DbLogic();
            d.connect(_configuration);
            ViewBag.category = d.fetchcat("selectcategoryname");

            return View();
        }

        [Route("/Admin/Admin/EditCat/{id}")]
        public IActionResult EditCat(int id)
        {
            DbLogic d = new DbLogic();
            d.connect(_configuration);
           Categoryfetch c= d.getCategoryByid("categoryByid",id);
            return View(c);
        }

        [HttpPost]
        [Route("/Admin/Admin/EditCat/{id}")]
        public IActionResult EditCat(int id,Categoryfetch c1)
        {
            DbLogic d = new DbLogic();
            d.connect(_configuration);
            Categoryfetch c = new Categoryfetch()
            {
                CatList = c1.CatList
            };
            d.catEdit("categoryEdit", id, c);
            return RedirectToAction("CategoryManage");
        }


        public IActionResult AddCat()
        {
           
            return View();

        }


        [HttpPost]
        public IActionResult AddCat(Categoryfetch c)
        {
            DbLogic d = new DbLogic();
            d.connect(_configuration);
            Categoryfetch c1 = new Categoryfetch()
            {
                CatList = c.CatList
            };
            d.addCat("categoryAdd", c1);
            return RedirectToAction("CategoryManage");

        }

        [Route("/Admin/Admin/DeleteCat/{id}")]
        public IActionResult DeleteCat(int id)
        {
            DbLogic d = new DbLogic();
            d.connect(_configuration);
            d.deleteCat("categoryDelete", id);
            return RedirectToAction("CategoryManage");
        }

        public IActionResult CommentHandle()
        {
            DbLogic dbLogic = new DbLogic();
            dbLogic.connect(_configuration);
           ViewBag.fetchcmt= dbLogic.fetchcomments("fetchcomment");
            return View();
        }

        [Route("Admin/Admin/DeleteComment{id}")]
        public IActionResult DeleteComment(int id) 
        {
            DbLogic dbLogic = new DbLogic();
            dbLogic.connect(_configuration);
            dbLogic.deletecomment("deletecmt",id);
            return RedirectToAction("CommentHandle");
        }

        public IActionResult readContect()
        {
            DbLogic dbLogic = new DbLogic();
            dbLogic.connect(_configuration);
           ViewBag.contect= dbLogic.getContectList("contectread");
            return View();
        }

        [Route("Admin/Admin/DeleteContect/{id}")]
        public IActionResult DeleteContect(int id)
        {
            DbLogic dbLogic = new DbLogic();
            dbLogic.connect(_configuration);
            dbLogic.deleteContect("deletecontect", id);
            return RedirectToAction("readContect");
        }


    }
}
