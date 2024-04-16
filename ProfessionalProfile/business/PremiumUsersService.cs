using ProfessionalProfile.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.business
{
    class PremiumUsersService
    {
        public PremiumUsersRepo PremiumUsersRepo { get; set; }

        public PremiumUsersService()
        {
            PremiumUsersRepo = new PremiumUsersRepo();
        }

        public List<int> GetPremiumUsers()
        {
            return PremiumUsersRepo.GetAll();
        }

        public bool isPremiumUser(int userId)
        {
            return this.PremiumUsersRepo.GetAll().Contains(userId);
        }

        public void AddPremiumUser(int userId)
        {
            this.PremiumUsersRepo.Add(userId);
        }
    }
}
