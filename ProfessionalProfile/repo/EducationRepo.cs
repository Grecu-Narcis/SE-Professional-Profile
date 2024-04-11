using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class EducationRepo : RepoInterface<Education>
    {
        public void Add(Education item)
        {
        }

        public void Delete(int id)
        {
        }

        public Education Get(int id)
        {
            Education education = new Education();
            return education;
        }

        public List<Education> GetAll()
        {
            List<Education> educations = new List<Education>();
            return educations;
        }

        public void Update(Education entity)
        {
        }
    }
}
