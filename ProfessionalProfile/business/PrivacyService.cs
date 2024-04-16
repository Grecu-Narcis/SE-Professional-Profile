using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.business
{
    class PrivacyService
    {
        PrivacyRepo PrivacyRepo { get; set; }

        public PrivacyService()
        {
            PrivacyRepo = new PrivacyRepo();
        }

        public void AddPrivacy(Privacy privacy)
        {
            PrivacyRepo.Add(privacy);
        }

        public void UpdatePrivacy(Privacy privacy)
        {
            PrivacyRepo.Update(privacy);
        }

        public Privacy GetPrivacy(int userId)
        {
            Privacy result = PrivacyRepo.GetById(userId);

            if (result != null) return result;
           
            this.AddPrivacy(new Privacy(userId, true, true, true, true, true, true));
            return PrivacyRepo.GetById(userId);
        }
    }
}
