using Models;
using System.Collections.Generic;

namespace Services
{
    public interface IAdminService
    {
        List<AdminViewModel> GetAllAdmins();
        void CreateAdmin(AdminViewModel admin);
        void DeleteAdmin(AdminViewModel admin);
    }
}
