using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    class Skill
    {
        private int _skill_id;
        private string _name;
        private string _skillLevel;

        public Skill(int skill_id, string name, string skillLevel)
        {
            this._skill_id = skill_id;
            this._name = name;
            this._skillLevel = skillLevel;
        }

        public int Skill_id{
            get { return _skill_id; }
            set { _skill_id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string SkillLevel
        {
            get { return _skillLevel; }
            set { _skillLevel = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Skill skill &&
                   _skill_id == skill._skill_id &&
                   _name == skill._name &&
                   _skillLevel == skill._skillLevel &&
                   Skill_id == skill.Skill_id &&
                   Name == skill.Name &&
                   SkillLevel == skill.SkillLevel;
        }
    }
}
