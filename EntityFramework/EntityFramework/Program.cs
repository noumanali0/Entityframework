using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BlogContext()) {
                Console.WriteLine("Enter name for Blog: ");
                string blogname = Console.ReadLine();


                Blog blog = new Blog();
                blog.Name = blogname;

                db.Blogs.Add(blog);
                db.SaveChanges();

                var query = from blg in db.Blogs select blg;

                foreach (var item in query) {
                    Console.WriteLine(item.ID+"   "+item.Name);   
                }




            }


        }
    }


    public class Blog {
        public int ID { get; set; }
        public string Name { get; set; }
    }


    public class Post {
        public int Postid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlodId { get; set; }
    }

    public class BlogContext : DbContext {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

    }



}
