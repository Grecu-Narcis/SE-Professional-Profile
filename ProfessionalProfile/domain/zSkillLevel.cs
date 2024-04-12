using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    // NOT USED
    public class SkillLevel
    {
        private int _skillLevelId;
        private string _level; // beginner, intermediate, advanced

        public SkillLevel(int skillLevelId, string level)
        {
            this._skillLevelId = skillLevelId;
            this._level = level;
        }

        public int SkillLevelId { 
            get {  return this._skillLevelId; } 
            set { this._skillLevelId = value; }
        }

        public string Level
        {
            get { return this._level; }
            set { this._level = value; }
        }
    }
}
