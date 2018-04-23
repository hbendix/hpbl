using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace Website.ApiControllers
{
    [Produces("application/json")]
    public class FeedController : Controller
    {
        private IImageService imageService;
        
        public FeedController(IImageService imageService) 
        {
            this.imageService = imageService;
        }
        [Route("api/Feed/GetFeed")]
        [HttpGet]
        public JsonResult GetFeed()
        {
            return Json(imageService.GetAllImages());
        }
        [Route("api/Admin/GetImages")]
        [HttpGet]
        public JsonResult GetAllImages()
        {
            return Json(imageService.GetAllAdminImages());
        }
        [Route("api/Admin/AddImage")]
        [HttpPost]
        public JsonResult AddImage(ImageViewModel image)
        {
            imageService.AddImage(image);
            return Json(image);
        }
        [Route("api/Admin/UpdateImage")]
        [HttpPut]
        public JsonResult UpdateImage(ImageViewModel image)
        {
            imageService.UpdateImage(image);
            return Json(image);
        }
        [Route("api/Admin/DeleteImage")]
        public void DeleteImage(ImageViewModel image)
        {
            imageService.DeleteImage(image);
        }
    }

}