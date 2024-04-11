using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class BussinesCard
    {
        private int _bc_id;
        private string _summary;
        private List<Skill> _keySkills;
        private string _uniqueUrl;
        private int _user_id;

        public BussinesCard(int bc_id, string summary, List<Skill> keySkills, string uniqueUrl, int user_id)
        {
            this._bc_id = bc_id;
            this._summary = summary;
            this._keySkills = keySkills;
            this._uniqueUrl = uniqueUrl;
            _user_id = user_id;
        }

        public int Bc_id
        {
            get { return _bc_id; }
            set { _bc_id = value; }
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

        public int User_id
        {
            get { return _user_id; }
            set { this._user_id = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is BussinesCard card &&
                   _bc_id == card._bc_id &&
                   _summary == card._summary &&
                   EqualityComparer<List<Skill>>.Default.Equals(_keySkills, card._keySkills) &&
                   _uniqueUrl == card._uniqueUrl &&
                   Bc_id == card.Bc_id &&
                   Summary == card.Summary &&
                   EqualityComparer<List<Skill>>.Default.Equals(KeySkills, card.KeySkills) &&
                   UniqueUrl == card.UniqueUrl;
        }
    }
}
