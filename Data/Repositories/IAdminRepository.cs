using Models;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IAdminRepository
    {
        List<Admin> GetAllAdmins();
        void CreateAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
        void Save();
    }
}