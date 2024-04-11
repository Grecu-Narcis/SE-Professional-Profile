using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class CertificationRepo : RepoInterface<Certification>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public void Add(Certification item)
        {
        }

        public void Delete(int id)
        {
        }

        public Certification Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Certification> GetAll()
        {
            List<Certification> certifications = new List<Certification>();
            return certifications;
        }

        public void Update(Certification entity)
        {
        }
    }
}
