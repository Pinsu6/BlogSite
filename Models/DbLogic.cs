using BlogApp.Areas.Admin.Models;
using BlogApp.Areas.Blog.Models;
using BlogApp.Areas.User.Models;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Runtime.Intrinsics.X86;
using Login = BlogApp.Areas.User.Models.Login;

namespace BlogApp.Models
{

    public class DbLogic
    {

        SqlConnection sqlConnection = null;
        SqlCommand SqlCommand = null;
        SqlDataReader sqlDataReader = null;

        public DbLogic()
        {


        }
        public void connect(IConfiguration configuration)
        {
            string url = configuration.GetConnectionString("BlogDb");
            sqlConnection = new SqlConnection(url);
           


        }
        public List<Blog> GetData(string procedurename)
        {
            sqlConnection.Open();

            List<Blog> b = new List<Blog>();
            SqlCommand = new SqlCommand(procedurename, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataReader = SqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Blog blog = new Blog()
                {
                    Id = sqlDataReader.GetInt32(0), 
                    blogname = sqlDataReader.GetString(1),
                    authname = sqlDataReader.GetString(2),
                    date = sqlDataReader.GetDateTime(3),
                    shortdesc = sqlDataReader.GetString(4),
                    image = sqlDataReader.GetString(5),
                };
                b.Add(blog);
            }
            sqlConnection.Close();

            return b;
        }

        public  Blog GetReadMoreData(string procedurename,int id)
        {
            sqlConnection.Open();

            Blog b =null;
            SqlCommand = new SqlCommand(procedurename, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("Id", id);
            sqlDataReader = SqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                 b = new Blog()
                {
                    Id = sqlDataReader.GetInt32(0), // Change to GetInt32 if Id is an integer
                    blogname = sqlDataReader.GetString(1),
                    authname = sqlDataReader.GetString(2),
                    date = sqlDataReader.GetDateTime(3),
                    shortdesc = sqlDataReader.GetString(4),
                    image = sqlDataReader.GetString(5),
                    descript=sqlDataReader.GetString(6)
                };
                
            }
            sqlConnection.Close();

            return b;
        }
        public int InsertUserData(String procedurename,RegisterUser r)
        {
            sqlConnection.Open();
            SqlCommand =new SqlCommand(procedurename, sqlConnection);
            SqlCommand.CommandType=System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@Name",r.Name);
            SqlCommand.Parameters.AddWithValue("@LName", r.LName);
            SqlCommand.Parameters.AddWithValue("@Email", r.Email);
            SqlCommand.Parameters.AddWithValue("@Password", r.Password);
           
            int result = SqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                sqlConnection.Close();
                return 1;
            }
            else
            {
                sqlConnection.Close();
                return 0;
            }


        }

        public Login Login(String procedure,Login l)
        {
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedure, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@Email", l.Email);
            SqlCommand.Parameters.AddWithValue("@Password", l.Password);
            sqlDataReader = SqlCommand.ExecuteReader();
            if (sqlDataReader.Read()) 
            {
                Login l1 = new Login()
                {
                    id = sqlDataReader.GetInt32(0),
                    name = sqlDataReader.GetString(1),
                    isAdmin = sqlDataReader.GetInt32(4)

                };
                sqlConnection.Close();
                return l1;
            }
            else
            {
                return null;
            }
            sqlConnection.Close();

            return null;
        }

        public Comment insertComment(String procedure, Comment c) 
        {
            Comment c1 = null;
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedure, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@cmt",c.cmt );
            SqlCommand.Parameters.AddWithValue("@User_id", c.user_id);
            SqlCommand.Parameters.AddWithValue("@blog_id", c.blog_id);
            sqlDataReader = SqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                c1 = new Comment()
                {
                    cmt=sqlDataReader.GetString(0),
                    user_id=sqlDataReader.GetInt32(1),
                    blog_id=sqlDataReader.GetInt32(2)
                };
            }
            sqlConnection.Close();
            return c1;
        }
       
        public Blog Search(String procedure, String blogname) 
        {
            sqlConnection.Open();
            Blog b = null;
            SqlCommand = new SqlCommand(procedure, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@title", blogname);
            sqlDataReader = SqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                b = new Blog()
                {
                    Id = sqlDataReader.GetInt32(0), // Change to GetInt32 if Id is an integer
                    blogname = sqlDataReader.GetString(1),
                    authname = sqlDataReader.GetString(2),
                    date = sqlDataReader.GetDateTime(3),
                    shortdesc = sqlDataReader.GetString(4),
                    image = sqlDataReader.GetString(5),
                    descript = sqlDataReader.GetString(6)
                };

            }
            sqlConnection.Close();
            return b;


           
        }

        public List<Comment> GetComments(string procedureName, int id)
        {
           
            {
                sqlConnection.Open();
                List<Comment> comments = new List<Comment>();
                using (SqlCommand sqlCommand = new SqlCommand(procedureName, sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@BlogId", id);

                    using (var sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            Comment comment = new Comment()
                            {
                                id=sqlDataReader.GetInt32(0),
                                cmt = sqlDataReader.GetString(1), 
                                Name = sqlDataReader.GetString(2),
                                user_id=sqlDataReader.GetInt32(3),
                            };

                            comments.Add(comment);
                        }
                    }
                }
                return comments;
            }
        }

        public int deleteComment(String procedureName, int id) 
        {
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedureName, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@id", id);
            int rowsAffected = SqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (rowsAffected > 0) 
            {
                return 1;
            }
            else
            {
                return 0;
            }


            
        }

        public List<Category> GetCategories(String procedure)
        {
            List<Category> categories = new List<Category>();
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedure, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataReader = SqlCommand.ExecuteReader();
            while (sqlDataReader.Read()) 
            {
                Category c = new Category()
                {
                    categoryname=sqlDataReader.GetString(1),
                };
                categories.Add(c);
            }
            sqlConnection.Close();
            return categories;
        }

        public List<Blog> GetCategoriesByName(String procedure,String categoryname)
        {
            List<Blog> b = new List<Blog>();
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedure, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@categoryname", categoryname);
            sqlDataReader = SqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Blog c = new Blog()
                {
                    Id = sqlDataReader.GetInt32(0),
                    blogname=sqlDataReader.GetString(3),
                    authname=sqlDataReader.GetString(4),
                    shortdesc=sqlDataReader.GetString(5),
                    image=sqlDataReader.GetString(6),

                };
                b.Add(c);
            }
            sqlConnection.Close();
            return b;
        }

        //admin logic start
        public int userCount(String procedurename)
        {
            int count = 0;
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedurename, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataReader  = SqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                count = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();
            return count;

        }

        public int blogCount(String procedurename)
        {
            int count = 0;
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedurename, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataReader = SqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                count = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();
            return count;

        }

        public Dictionary<String,int> categoryCount(String procedurename)
        {
            int count = 0;
            Dictionary<string, int> m = new Dictionary<string, int>();
            String catname;
            
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedurename, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataReader = SqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                catname = sqlDataReader.GetString(0);
                count = sqlDataReader.GetInt32(1);
                m.Add(catname, count);
            }
            sqlConnection.Close();
            return m;

        }

        public List<Categoryfetch> fetchcat(String procedurename) 
        {
            
             sqlConnection.Open();
             List<Categoryfetch> list = new List<Categoryfetch>();
            SqlCommand = new SqlCommand(procedurename, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
           
            
                sqlDataReader = SqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Categoryfetch cat = new Categoryfetch()
                    {
                        Id = sqlDataReader.GetInt32(0),
                        CatList=sqlDataReader.GetString(1)

                    };
                    list.Add(cat);
                }
            
           

            sqlConnection.Close();
            return list;
        }

        public int AddBlog(String procedurename,Insertblog b1)
        {
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedurename, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@blogname", b1.Blogname);
            SqlCommand.Parameters.AddWithValue("@authname", b1.AuthName);
            SqlCommand.Parameters.AddWithValue("@shortdesc", b1.ShortDesc);
            SqlCommand.Parameters.AddWithValue("@image", b1.Image);
            SqlCommand.Parameters.AddWithValue("@descript", b1.Descript);
            SqlCommand.Parameters.AddWithValue("@category", b1.Category);
            int i = SqlCommand.ExecuteNonQuery();
           
            sqlConnection.Close();
            sqlConnection.Open();
      
            sqlConnection.Close();

            return 1;
        }

        public Insertblog getBlogById(String procedure,int id)
        {
            Insertblog b1 = null;
            sqlConnection.Open();
            
           SqlCommand = new SqlCommand(procedure, sqlConnection);
            
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = SqlCommand.ExecuteReader();
            if (dr.Read()) 
            {
                 b1 = new Insertblog()
                {
                    Id = dr.GetInt32(0),
                    Blogname = dr.GetString(1),
                    AuthName = dr.GetString(2),
                    ShortDesc = dr.GetString(4),
                    Image= dr.GetString(5),
                    Descript = dr.GetString(6),

                };
               
            }
            sqlConnection.Close();  
            return b1;

        }

        public int updateBlog(String procedure, int id,Insertblog b3)
        {
           
                sqlConnection.Open();


            SqlCommand = new SqlCommand(procedure, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@BlogID", id);
            SqlCommand.Parameters.AddWithValue("@Title", b3.Blogname);
            SqlCommand.Parameters.AddWithValue("@Author",b3.AuthName);
            SqlCommand.Parameters.AddWithValue("@ShortDescription",b3.ShortDesc);
            SqlCommand.Parameters.AddWithValue("@Description", b3.Descript);
            SqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return 1;
        }

        public int deleteBlog(String procedurename,int id) 
        {
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedurename, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@id", id);
           int r= SqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return r;
        }

        public Categoryfetch getCategoryByid(String procedure, int id)
        {
            sqlConnection.Open();
            Categoryfetch categoryfetch =null;
            SqlCommand = new SqlCommand(procedure, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = SqlCommand.ExecuteReader();
            if(dr.Read())
            {
                categoryfetch = new Categoryfetch()
                {
                    Id = dr.GetInt32(0),
                    CatList = dr.GetString(1)
                };
            }
            sqlConnection.Close();
            return categoryfetch;
        }


        public int catEdit(String procedurename, int id,Categoryfetch c) 
        {
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedurename, sqlConnection);
            SqlCommand.CommandType= System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@catid", id);
            SqlCommand.Parameters.AddWithValue("@categoryname", c.CatList);
            SqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return 1;
        }

        public int addCat(String procedure,Categoryfetch c)
        {
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedure,sqlConnection);
            SqlCommand.CommandType=System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@categoryname", c.CatList);
            SqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return 1;
        }

        public int deleteCat(String procedure,int id)
        {
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedure,sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@catid", id);
            SqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return 1;
        }

        public List<fetchcomment> fetchcomments(String procedure) 
        {
            sqlConnection.Open();
            List<fetchcomment> l1 = new List<fetchcomment>();
            SqlCommand = new SqlCommand(procedure, sqlConnection);
            SqlCommand.CommandType= System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = SqlCommand.ExecuteReader();
            while (dr.Read()) 
            {
                fetchcomment comment = new fetchcomment()
                {
                    id = dr.GetInt32(0),
                    comment=dr.GetString(1),
                    Name=dr.GetString(2),
                    BlogName=dr.GetString(3),
                };
                l1.Add(comment);

            }
            sqlConnection.Close();
            return l1;
        }

        public int deletecomment(String procedure,int id)
        {
            sqlConnection.Open();
            SqlCommand = new SqlCommand(procedure,sqlConnection);
            SqlCommand.CommandType=System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return 1;
        }

        public void addContect(String procedure,Contect c)
        {
            sqlConnection.Open();
                SqlCommand=new SqlCommand(procedure,sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@name", c.Name);
            SqlCommand.Parameters.AddWithValue("@email", c.Email);
            SqlCommand.Parameters.AddWithValue("@phone", c.Phone);
            SqlCommand.Parameters.AddWithValue("@message", c.Message);
            SqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Contect> getContectList(String procedure) 
        {
            sqlConnection.Open();
            List<Contect> c = new List<Contect> ();
            SqlCommand = new SqlCommand(procedure, sqlConnection);
            SqlCommand.CommandType=System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = SqlCommand.ExecuteReader();
            while (dr.Read()) 
            {
                Contect c1 = new Contect()
                {
                    Id = dr.GetInt32(0),
                    Name = dr.GetString(1),
                    Email = dr.GetString(2),
                    Phone = dr.GetString(3),
                    Message = dr.GetString(4),
                };
                c.Add(c1);
            }
            sqlConnection.Close();
            return c;
        }

        public int deleteContect(String procedur,int id) 
        {
            sqlConnection.Open();
            SqlCommand= new SqlCommand(procedur, sqlConnection);
            SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return 1;
        }
    }
}
