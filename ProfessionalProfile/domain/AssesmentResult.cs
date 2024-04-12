using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class AssesmentResult
    {
        private int _assesmentr_id;
        private int _assesmentt_id;
        private int _score;
        private int _user_id;

        public AssesmentResult(int assesmentr_id, int assesmentt_id, int score, int user_id)
        {
            _assesmentr_id = assesmentr_id;
            _assesmentt_id = assesmentt_id;
            _score = score;
            _user_id = user_id;
        }

        public int Assesmentr_id {
            get { return _assesmentr_id; }
            set { _assesmentr_id = value; }
        }

        public int Assesmentt_id
        {
            get { return _assesmentt_id; }
            set { _assesmentt_id = value; }
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
            return obj is AssesmentResult result &&
                    _assesmentr_id == result._assesmentr_id &&
                    _assesmentt_id == result._assesmentt_id &&
                    _score == result._score && 
                    _user_id == result._user_id &&
                    Assesmentr_id == result.Assesmentr_id &&
                    Assesmentt_id == result.Assesmentt_id &&
                    Score == result.Score &&
                    User_id == result.User_id;
        }
    }
}
