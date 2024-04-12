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
        private string _skillLevel;

        public Skill(int skillId, string name, string skillLevel)
        {
            this._skillId = skillId;
            this._name = name;
            this._skillLevel = skillLevel;
        }

        public int SkillId{
            get { return _skillId; }
            set { _skillId = value; }
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
                   _skillId == skill._skillId &&
                   _name == skill._name &&
                   _skillLevel == skill._skillLevel &&
                   SkillId == skill.SkillId &&
                   Name == skill.Name &&
                   SkillLevel == skill.SkillLevel;
        }
    }
}
