using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class EndorsementRepo : RepoInterface<Endorsement>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public void Add(Endorsement item)
        {
        }

        public void Delete(int id)
        {
        }

        public Endorsement Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Endorsement> GetAll()
        {
            List<Endorsement> endorsements = new List<Endorsement>();
            return endorsements;
        }

        public void Update(Endorsement entity)
        {
        }
    }
}
