using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class EndorsementRepo : RepoInterface<Endorsement>
    {
        public void Add(Endorsement item)
        {
        }

        public void Delete(int id)
        {
        }

        public List<Endorsement> GetAll()
        {
            List<Endorsement> endorsements = new List<Endorsement>();
            return endorsements;
        }

        public Endorsement GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Endorsement item)
        {
        }
    }
}
