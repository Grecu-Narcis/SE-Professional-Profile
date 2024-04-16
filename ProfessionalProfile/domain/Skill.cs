using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class Skill
    {
        private int _skillId;
        private string _name;
        

        public Skill(int skillId, string name)
        {
            this._skillId = skillId;
            this._name = name;
        }

        public int SkillId
        {
            get { return _skillId; }
            set { _skillId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Skill skill &&
                   _skillId == skill._skillId &&
                   _name == skill._name &&
                   SkillId == skill.SkillId &&
                   Name == skill.Name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
