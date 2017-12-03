using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private WebsiteContext websiteContext;
        public ImageRepository(WebsiteContext websiteContext)
        {
            this.websiteContext = websiteContext;
        }
        public void Add(Image image)
        {
            this.websiteContext.Add(image);
        }
        public void Save()
        {
            this.websiteContext.SaveChanges();
        }
        public void Update(Image image)
        {
            websiteContext.Entry(image).State = EntityState.Modified;
        }
        public void DeleteImage(Image image)
        {
            this.websiteContext.Remove(image);
        }
        public List<Image> GetAllImages()
        {
            return websiteContext.Images
                .OrderBy(r => Guid.NewGuid())
                .Take(10)
                .ToList();             
        }
        public List<Image> GetAllImagesList()
        {
            return websiteContext.Images
               .OrderByDescending(x => x.Id)
               .ToList();
        }
        public Image GetImageById(int id)
        {
            return this.websiteContext.Images.Find(id);
        }

        public List<Image> GetImagesByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }        
    }
}
