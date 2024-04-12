using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class CertificationRepo : RepoInterface<Certification>
    {
        public void Add(Certification item)
        {
        }

        public void Delete(int id)
        {
        }

        public List<Certification> GetAll()
        {
            List<Certification> certifications = new List<Certification>();
            return certifications;
        }

        public Certification GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Certification item)
        {
        }
    }
}
