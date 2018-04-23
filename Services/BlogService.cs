using System.Collections.Generic;
using Models.ViewModels;
using Data.Repositories;
using AutoMapper;
using Models.Models;
using System.Linq;

namespace Services
{
    public class BlogService : IBlogService
    {
        private IBlogRepository blogRepository;
        private IMapper mapper;
        public BlogService(IBlogRepository blogRepository,
            IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.mapper = mapper;
        }
        public void CreateBlog(BlogViewModel blog)
        {
            var blogEntity = mapper.Map<BlogViewModel, Blog>(blog);
            blogRepository.CreateBlog(blogEntity);
            blogRepository.Save();
        }

        public void DeleteBlog(BlogViewModel blog)
        {
            var blogEntity = mapper.Map<BlogViewModel, Blog>(blog);
            blogRepository.DeleteBlog(blogEntity);
            blogRepository.Save();
        }

        public List<BlogViewModel> GetAllBlogs()
        {    
            var blogsEntity =  blogRepository.GetAllBlogs();
            return blogsEntity.Select(x => mapper.Map<Blog, BlogViewModel>(x)).ToList();
        }

        public List<BlogViewModel> GetBlogFeed()
        {
            var blogsEntity = blogRepository.GetBlogFeed();
            return blogsEntity.Select(x => mapper.Map<Blog, BlogViewModel>(x)).ToList();
        }
    }
}
