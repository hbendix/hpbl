namespace Website.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Models;
    using Models.ViewModels;

    public class AdminController : Controller
    {
        private IAdminService adminService;
        private IImageService imageService;
        private IBlogService blogService;

        public AdminController(IAdminService adminService,
            IImageService imageService,
            IBlogService blogService)
        {
            this.adminService = adminService;
            this.imageService = imageService;
            this.blogService = blogService;
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Index()
        {
            ViewBag.HideNavBar = true;
            return View();
        }  
        public IActionResult Login()
        {
            return View();
        }
        /* IMAGE CONTROL ------------------------------------------------------------------- IMAGE CONTROL*/
        [Route("/admin/imagecontrol")]
        public IActionResult ImageControl()
        {
            return View();
        }        
        [HttpGet]
        public JsonResult GetAllImages()
        {
            return Json(imageService.GetAllAdminImages());
        }
        [HttpPost]
        public JsonResult AddImage(ImageViewModel image)
        {
            imageService.AddImage(image);
            return Json(image);
        }
        [HttpPost]
        public JsonResult UpdateImage(ImageViewModel image)
        {
            imageService.UpdateImage(image);
            return Json(image);
        }
        [HttpPost]
        public void DeleteImage(ImageViewModel image)
        {
            imageService.DeleteImage(image);
        }
        /* ADMIN CONTROL ------------------------------------------------------------------- ADMIN CONTROL*/

        [Route("/admin/admincontrol")]
        public IActionResult AdminControl()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAllAdmins()
        {
            return Json(adminService.GetAllAdmins());
        }
        [HttpPost]        
        public JsonResult CreateAdmin(AdminViewModel admin)
        {
            if((admin.Username == null) || (admin.Password == null))
            {
                return Json("e");
            }
            adminService.CreateAdmin(admin);
            return Json(admin);
        }
        public void DeleteAdmin(AdminViewModel admin)
        {
            adminService.DeleteAdmin(admin);
        }

        /* BLOG CONTROL ------------------------------------------------------------------- BLOG CONTROL*/
        [Route("/admin/blogcontrol")]
        public IActionResult BlogControl()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAllBlogPosts()
        {
            return Json(blogService.GetAllBlogs());
        }
        [HttpPost]
        public void CreateBlog(BlogViewModel blog)
        {
            blogService.CreateBlog(blog);
        }
        [HttpPost]
        public void DeleteBlog(BlogViewModel blog)
        {
            blogService.DeleteBlog(blog);
        }
    }
}