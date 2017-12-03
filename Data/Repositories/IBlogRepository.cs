using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IBlogRepository
    {
        List<Blog> GetAllBlogs();
        List<Blog> GetBlogFeed();
        List<Blog> GetBlogsByDate(DateTime dateTime);
        Blog GetBlogById(int id);
        void CreateBlog(Blog image);
        void Save();
        void DeleteBlog(Blog image);
    }
}
