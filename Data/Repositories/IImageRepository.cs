using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IImageRepository
    {        
        List<Image> GetAllImages();
        List<Image> GetAllImagesList();
        List<Image> GetImagesByDate(DateTime dateTime);
        Image GetImageById(int id);
        void Add(Image image);
        void Update(Image image);
        void Save();
        void DeleteImage(Image image);
    }
}
