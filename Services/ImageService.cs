namespace Services
{
    using Models;
    using Data.Repositories;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class ImageService : IImageService
    {
        private IImageRepository imageRepository;
        private IMapper mapper;

        public ImageService(IImageRepository imageRepository,
            IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }
        public List<ImageViewModel> GetAllImages()
        {
            var imageEntities = imageRepository.GetAllImages();
            var shuffledImages = imageEntities.OrderBy(a => Guid.NewGuid()).ToList();
            return shuffledImages.Select(x => mapper.Map<Image, ImageViewModel>(x)).ToList();            
        }
        public List<ImageViewModel> GetAllAdminImages()
        {
            var imageEntities = imageRepository.GetAllImagesList();
            return imageEntities.Select(x => mapper.Map<Image, ImageViewModel>(x)).ToList();
        }
        public void AddImage(ImageViewModel image)
        {
            var imageEntity = mapper.Map<ImageViewModel, Image>(image);
            imageRepository.Add(imageEntity);
            imageRepository.Save();
        }
        public void DeleteImage(ImageViewModel image)
        {
            var imageEntity = mapper.Map<ImageViewModel, Image>(image);
            imageRepository.DeleteImage(imageEntity);
            imageRepository.Save();
        }

        public void UpdateImage(ImageViewModel image)
        {
            var imageEntity = mapper.Map<ImageViewModel, Image>(image);
            imageRepository.Update(imageEntity);
            imageRepository.Save();
        }
    }
}
