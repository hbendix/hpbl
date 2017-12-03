using System;
using System.Collections.Generic;
using System.Text;
using Models.Models;
using System.Linq;

namespace Data.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private WebsiteContext websiteContext;
        public BlogRepository(WebsiteContext websiteContext)
        {
            this.websiteContext = websiteContext;
        }
        public void CreateBlog(Blog blog)
        {
            this.websiteContext.Add(blog);
        }

        public void DeleteBlog(Blog blog)
        {
            this.websiteContext.Remove(blog);
        }

        public List<Blog> GetAllBlogs()
        {
            return websiteContext.Blogs.ToList();
        }

        public Blog GetBlogById(int id)
        {
            return websiteContext.Blogs
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public List<Blog> GetBlogFeed()
        {
            return websiteContext.Blogs
                .Take(3)
                .OrderByDescending(x => x.Created)
                .ToList();
        }

        public List<Blog> GetBlogsByDate(DateTime dateTime)
        {
            return websiteContext.Blogs
                .Where(x => x.Created == dateTime)
                .ToList();
        }

        public void Save()
        {
            this.websiteContext.SaveChanges();
        }
    }
}
