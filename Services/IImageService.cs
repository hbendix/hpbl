using Models;
using System.Collections.Generic;

namespace Services
{
    public interface IImageService
    {
        List<ImageViewModel> GetAllImages();
        List<ImageViewModel> GetAllAdminImages();
        void UpdateImage(ImageViewModel image);
        void DeleteImage(ImageViewModel image);
        void AddImage(ImageViewModel image);
    }
}
