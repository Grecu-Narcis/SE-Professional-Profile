using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class SkillRepo : RepoInterface<Skill>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public void Add(Skill item)
        {
        }

        public void Delete(int id)
        {
        }

        public Skill Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetAll()
        {
            List<Skill> skills = new List<Skill>();
            return skills;
        }

        public void Update(Skill entity)
        {
        }
    }
}
