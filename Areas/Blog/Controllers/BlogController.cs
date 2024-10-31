using BlogApp.Areas.Blog.Models;
using BlogApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Newtonsoft.Json;
using System.Configuration;

namespace BlogApp.Areas.Blog.Controllers
{
    [Area("Blog")]
	public class BlogController : Controller
	{
		IConfiguration _configuration;
		public BlogController(IConfiguration configuration)
		{
			
			this._configuration = configuration;
           
        }
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            DbLogic d = new DbLogic();
            GetCatName g = new GetCatName();
            d.connect(_configuration);

            // Get all blogs from database
            List<Areas.Blog.Models.Blog> b = d.GetData("GetBlogs");

            var categories = d.GetCategories("selectcategoryname");
            g.categoryname = categories; // Set categories to g.categoryname if it's a List<YourCategoryType>

            // Serialize the list to JSON and store it in the session
            HttpContext.Session.SetString("cat", JsonConvert.SerializeObject(g.categoryname));
            // Paginate data for the current page
            var pagedBlogs = b.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            g.blogs = pagedBlogs; // Assign only paginated data to the model

            // Calculate total pages and set ViewBag properties for pagination controls
            ViewBag.TotalPages = Math.Ceiling((double)b.Count / pageSize);
            ViewBag.CurrentPage = page;

            return View(g); // Return paginated data to the view
        }


        [Route("Blog/ReadMore/{id}")]
        public IActionResult Readmore(int id)
		{
			

            if (HttpContext.Session.GetString("User")!=null)
			{
                TempData["id"] = id;
                TempData["UserId"] = (int)HttpContext.Session.GetInt32("UserId");
                DbLogic db = new DbLogic();
				db.connect(_configuration);
                var data=db.GetReadMoreData("DetailBlog", id);
				ViewBag.cmt = db.GetComments("commentInfo", id);
                return View(data);
            }
			else
			{
				return RedirectToAction("Login", "User", new { area = "User" });
			}
			
		}
		[HttpPost]
		public IActionResult Search(String SearchBlog=null) 
		{
            DbLogic d = new DbLogic();
			d.connect(_configuration);
			if (String.IsNullOrEmpty(SearchBlog)) 
			{
				return RedirectToAction("index");
			}
			else
			{
                var searchResult = d.Search("search", SearchBlog);
                ViewBag.blog = searchResult;

                Console.Write("Data is " +ViewBag.blog);
				if (ViewBag.blog == null) 
				{
					ViewBag.error = "Not found";
					return View();
				}
				else
				{
                    return View(searchResult);
                }
               

            }
			
            
			

           
        }

        [HttpPost]

        public IActionResult Comment(System.String comment = null)
        {
            Comment c = new Comment();
            DbLogic d = new DbLogic();
            d.connect(_configuration);
            c.blog_id = (int)TempData.Peek("id");
            c.user_id = (int)TempData.Peek("UserId");
            c.cmt = comment;
            Comment c2 = d.insertComment("insertcomment", c);
            return RedirectToAction("Readmore", "Blog", new { id = c.blog_id });
        }

		
		[Route("Blog/deleteComment/{id}")]
		public IActionResult deleteComment(int id) 
		{
			DbLogic d = new DbLogic();
            Comment c = new Comment();
            c.blog_id = (int)TempData.Peek("id");
            d.connect(_configuration);
			int data=d.deleteComment("deleteComment", id);
			if(data>0)
			{
                return RedirectToAction("Readmore", "Blog", new { id = c.blog_id });
            }
            return RedirectToAction("Readmore", "Blog", new { id = c.blog_id });
            

        }

	
		[Route("Blog/Blog/Category/{Name}")]
        public IActionResult Category(String Name)
        {
           List<Models.Blog> b = new List<Models.Blog>();
                DbLogic d = new DbLogic();
                d.connect(_configuration);

                 b= d.GetCategoriesByName("catnormdata", Name);
                ViewBag.CategoryName = Name;
                return View(b);
        }
    }
}
