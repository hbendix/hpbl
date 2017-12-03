using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private WebsiteContext websiteContext;

        public AdminRepository(WebsiteContext websiteContext)
        {
            this.websiteContext = websiteContext;
        }
        public List<Admin> GetAllAdmins()
        {
            return websiteContext.Admins.ToList();
        }
        public void CreateAdmin(Admin admin)
        {
            this.websiteContext.Add(admin);
        }
        public void UpdateAdmin(Admin admin)
        {
            this.websiteContext.Update(admin);
        }
        public void Save()
        {
           this.websiteContext.SaveChanges();
        }       
        public void DeleteAdmin(Admin admin)
        {
            websiteContext.Remove(admin);
        }
    }
}
