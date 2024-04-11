using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    // NOT USED
    class SkillLevel
    {
        private int _skillLevel_id;
        private string _level; // beginner, intermediate, advanced

        public SkillLevel(int skillLevel_id, string level)
        {
            this._skillLevel_id = skillLevel_id;
            this._level = level;
        }

        public int SkillLevel_id { 
            get {  return this._skillLevel_id; } 
            set { this._skillLevel_id = value; }
        }

        public string Level
        {
            get { return this._level; }
            set { this._level = value; }
        }
    }
}
