using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class WorkExperienceRepo : RepoInterface<WorkExperience>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public void Add(WorkExperience item)
        {
        }

        public void Delete(int id)
        {
        }

        public WorkExperience Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<WorkExperience> GetAll()
        {
            List<WorkExperience> workExperiences = new List<WorkExperience>();
            return workExperiences;
        }

        public void Update(WorkExperience entity)
        {
        }
    }
}
