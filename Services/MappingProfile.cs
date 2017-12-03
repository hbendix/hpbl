using AutoMapper;
using Models;
using Models.Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Admin, AdminViewModel>()
                .ReverseMap();
            CreateMap<Image, ImageViewModel>()
                .ReverseMap();
            CreateMap<Blog, BlogViewModel>()
                .ReverseMap();
        }
    }
}
