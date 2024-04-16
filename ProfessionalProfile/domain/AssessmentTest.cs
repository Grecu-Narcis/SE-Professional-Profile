using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class AssessmentTest
    {
        private int _assessmentTestId;
        private string _testName;
        private int _userId;
        private string _description;
        private int _skill_id;

        public AssessmentTest(int assest_id, string testName, int userId, string description, int skillsAssessed)
        {
            this._assessmentTestId = assest_id;
            this._testName = testName;
            this._userId = userId;
            this._description = description;
            this._skill_id = skillsAssessed;
        }

        public int AssessmentTestId
        {
            get { return _assessmentTestId; }
            set { _assessmentTestId = value; }
        }

        public string TestName
        {
            get { return _testName; }
            set { _testName = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Skill_id{
            get {  return _skill_id; }
            set { _skill_id = value;}
        }

        public override bool Equals(object? obj)
        {
            return obj is AssessmentTest test &&
                   _assessmentTestId == test._assessmentTestId &&
                   _testName == test._testName &&
                   _userId == test._userId &&
                   _description == test._description &&
                   _skill_id == test._skill_id &&
                   AssessmentTestId == test.AssessmentTestId &&
                   TestName == test.TestName &&
                   UserId == test.UserId &&
                   Description == test.Description &&
                   Skill_id == test.Skill_id;
        }

        public override string ToString()
        {
            return _testName + "\n" + _description;
        }
    }
}
