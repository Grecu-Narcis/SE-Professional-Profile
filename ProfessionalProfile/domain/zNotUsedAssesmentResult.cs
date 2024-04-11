using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    //NOT USED
    public class zNotUsedAssesmentResult
    {
        private int _assesmentr_id;
        private int _user_id;
        private int _score;

        public zNotUsedAssesmentResult(int assesr_id, int score, int user_id )
        {
            this._assesmentr_id = assesr_id;
            this._user_id = user_id;
            this._score = score;
            
        }
        public int Assesmentr_id {
            get { return _assesmentr_id; }
            set { _assesmentr_id = value; }
        }
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public int User_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is zNotUsedAssesmentResult result &&
                   _assesmentr_id == result._assesmentr_id &&
                   _user_id == result._user_id &&
                   _score == result._score &&
                   Assesmentr_id == result.Assesmentr_id &&
                   Score == result.Score &&
                   User_id == result.User_id;
        }
    }
}
