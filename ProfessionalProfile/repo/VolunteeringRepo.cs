using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class VolunteeringRepo : RepoInterface<Volunteering>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public void Add(Volunteering item)
        {
            
        }

        public void Delete(int id)
        {
            
        }

        public Volunteering Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Volunteering> GetAll()
        {
            List<Volunteering> volunteerings
                = new List<Volunteering>();
            return volunteerings
        }

        public void Update(Volunteering entity)
        {
            
        }
    }
}
