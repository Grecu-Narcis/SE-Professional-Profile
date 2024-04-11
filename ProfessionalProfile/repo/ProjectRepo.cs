using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class ProjectRepo : RepoInterface<Project>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public void Add(Project item)
        {
        }

        public void Delete(int id)
        {
        }

        public Project Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAll()
        {
            List<Project> projects = new List<Project>();
            return projects;
        }

        public void Update(Project entity)
        {
        }
    }
}
