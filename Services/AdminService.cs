using Models;
using AutoMapper;
using Data.Repositories;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Services
{
    public class AdminService : IAdminService
    {         
        private IMapper mapper;
        private IAdminRepository adminRepository;

        public AdminService(IMapper mapper,
            IAdminRepository adminRepository)
        {
            this.mapper = mapper;
            this.adminRepository = adminRepository;
        }
        
        public void CreateAdmin(AdminViewModel admin)
        {
            admin.DateAdded = DateTime.Now;
            var adminEntity = mapper.Map<AdminViewModel, Admin>(admin);
            adminRepository.CreateAdmin(adminEntity);
            adminRepository.Save();
        }

        public void DeleteAdmin(AdminViewModel admin)
        {
            var entity = mapper.Map<AdminViewModel, Admin>(admin);
            adminRepository.DeleteAdmin(entity);
            adminRepository.Save();
        }

        public List<AdminViewModel> GetAllAdmins()
        {
            var adminEntities = adminRepository.GetAllAdmins();
            return adminEntities.Select(x => mapper.Map<Admin, AdminViewModel>(x)).ToList();
        }
    }
}
