using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    class Privacy
    {
        public int userId { get; set; }
        public bool canViewEducation { get; set; }
        public bool canViewWorkExperience { get; set; }
        public bool canViewSkills { get; set; }
        public bool canViewProjects { get; set; }
        public bool canViewCertificates { get; set; }
        public bool canViewVolunteering { get; set; }

        public Privacy(int userId, bool canViewEducation, bool canViewWorkExperience, bool canViewSkills, bool canViewProjects, bool canViewCertificates, bool canViewVolunteering)
        {
            this.userId=userId;
            this.canViewEducation=canViewEducation;
            this.canViewWorkExperience=canViewWorkExperience;
            this.canViewSkills=canViewSkills;
            this.canViewProjects=canViewProjects;
            this.canViewCertificates=canViewCertificates;
            this.canViewVolunteering=canViewVolunteering;
        }
    }
}
