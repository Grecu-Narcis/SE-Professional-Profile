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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
        }

        public Certification Get(int id)
        {
            Certification certification = new Certification();
            return certification;
        }

        public List<Certification> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Certification entity)
        {
            throw new NotImplementedException();
        }
    }
}
