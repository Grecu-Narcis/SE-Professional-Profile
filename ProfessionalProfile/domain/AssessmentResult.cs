using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class AssessmentResult
    {
        private int _assesmentResultId;
        private int _assesmentTestId;
        private int _score;
        private int _userId;
        private DateTime _testDate;

        public AssessmentResult(int assesmentResultId, int assesmentt_id, int userId, int score,  DateTime testDate)
        {
            this._assesmentResultId = assesmentResultId;
            this._assesmentTestId = assesmentt_id;
            this._score = score;
            this._userId = userId;
            this._testDate = testDate;
        }

        public int AssessmentResultId {
            get { return _assesmentResultId; }
            set { _assesmentResultId = value; }
        }

        public int AssessmentTestId
        {
            get { return _assesmentTestId; }
            set { _assesmentTestId = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }   

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public DateTime TestDate
        {
            get { return this._testDate; }
            set
            {
                this._testDate = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is AssessmentResult result &&
                    _assesmentResultId == result._assesmentResultId &&
                    _assesmentTestId == result._assesmentTestId &&
                    _score == result._score &&
                    _userId == result._userId &&
                    _testDate == result._testDate &&
                    AssessmentResultId == result.AssessmentResultId &&
                    AssessmentTestId == result.AssessmentTestId &&
                    Score == result.Score &&
                    UserId == result.UserId &&
                    TestDate == result.TestDate;
        }

        public override string ToString()
        {
            return _score.ToString();
        }
    }
}
