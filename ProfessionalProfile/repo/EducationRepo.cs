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

        public List<Education> GetAll()
        {
            List<Education> educations = new List<Education>();
            return educations;
        }

        public Education GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Education item)
        {
        }
    }
}
