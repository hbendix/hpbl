using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IBlogService
    {
        List<BlogViewModel> GetAllBlogs();
        List<BlogViewModel> GetBlogFeed();
        void CreateBlog(BlogViewModel blog);
        void DeleteBlog(BlogViewModel blog);
    }
}
