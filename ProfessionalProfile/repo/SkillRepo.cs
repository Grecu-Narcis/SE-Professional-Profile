using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class SkillRepo : RepoInterface<Skill>
    {
        public void Add(Skill item)
        {
        }

        public void Delete(int id)
        {
        }

        public List<Skill> GetAll()
        {
            List<Skill> skills = new List<Skill>();
            return skills;
        }

        public Skill GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Skill item)
        {
        }
    }
}
