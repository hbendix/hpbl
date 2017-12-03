using Models;
using Microsoft.EntityFrameworkCore;
using System;
using Models.Models;

namespace Data
{
    public class WebsiteContext : DbContext
    {
        public WebsiteContext(DbContextOptions options) : base(options) {  }
        public DbSet<Image> Images { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
