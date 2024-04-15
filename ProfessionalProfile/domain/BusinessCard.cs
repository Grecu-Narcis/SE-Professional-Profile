using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class BussinesCard
    {
        private int _bcId;
        private int _userId;
        private string _summary;
        private string _uniqueUrl;
        private List<Skill> _keySkills;

        public BussinesCard(int bcId, string summary, string uniqueUrl, int userId, List<Skill> keySkills)
        {
            this._bcId = bcId;
            this._summary = summary;
            this._keySkills = keySkills;
            this._uniqueUrl = uniqueUrl;
            _userId = userId;
        }

        public int BcId
        {
            get { return _bcId; }
            set { _bcId = value; }
        }

        public string Summary
        { 
            get { return _summary; } 
            set {  _summary = value; } 
        }

        public List<Skill> KeySkills
        {
            get { return _keySkills;}
            set { this._keySkills=value;}
        }
        public string UniqueUrl
        {
            get { return _uniqueUrl; }
            set { _uniqueUrl = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { this._userId = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is BussinesCard card &&
                   _bcId == card._bcId &&
                   _summary == card._summary &&
                   EqualityComparer<List<Skill>>.Default.Equals(_keySkills, card._keySkills) &&
                   _uniqueUrl == card._uniqueUrl &&
                   BcId == card.BcId &&
                   Summary == card.Summary &&
                   EqualityComparer<List<Skill>>.Default.Equals(KeySkills, card.KeySkills) &&
                   UniqueUrl == card.UniqueUrl;
        }
    }
}
