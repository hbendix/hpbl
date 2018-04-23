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
            bool first = true;
            var IDs = new List<int>();
            var imageEntities = imageRepository.GetAllImages();
            IDs.AddRange(imageEntities.Select(x => x.Id));
            if (!first)
            {
                foreach (var image in imageEntities)
                {
                    if (IDs.Contains(image.Id))
                    {
                        imageEntities.Remove(image);
                    }
                }
            }
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
