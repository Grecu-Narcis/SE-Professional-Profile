using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class AssesmentResult
    {
        private int _assesr_id;
        private int _overallScore;
        private Dictionary<int, int> _skillScores;

        public AssesmentResult(int assesr_id, int overallScore, Dictionary<int, int> skillScores)
        {
            this._assesr_id = assesr_id;
            this._overallScore = overallScore;
            this._skillScores = skillScores;
        }
        public int Assesr_id {
            get { return _assesr_id; }
            set { _assesr_id = value; }
        }
        public int Score
        {
            get { return _overallScore; }
            set { _overallScore = value; }
        }

        public Dictionary<int,int> SkillScores
        {
            get { return _skillScores; }
            set { _skillScores = value; }
        }

        public void setScoreBySkill(int skillId, int skillScore){
            _skillScores[skillId] = skillScore;
        }

        public int getScoreBySkill(int skillId)
        {
            return _skillScores[skillId];
        }

        public override bool Equals(object? obj)
        {
            return obj is AssesmentResult result &&
                   _assesr_id == result._assesr_id &&
                   _overallScore == result._overallScore &&
                   EqualityComparer<Dictionary<int, int>>.Default.Equals(_skillScores, result._skillScores) &&
                   Assesr_id == result.Assesr_id &&
                   Score == result.Score &&
                   EqualityComparer<Dictionary<int, int>>.Default.Equals(SkillScores, result.SkillScores);
        }
    }
}
