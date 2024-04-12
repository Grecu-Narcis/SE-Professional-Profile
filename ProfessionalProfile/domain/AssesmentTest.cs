using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class AssesmentTest
    {
        private int _assest_id;
        private string _testName;
        private string _description;
        private string _skill_id;

        public AssesmentTest(int assest_id, string testName, string description, string skillsAssessed)
        {
            this._assest_id = assest_id;
            this._testName = testName;
            this._description = description;
            this._skill_id = skillsAssessed;
        }

        public int Assest_id
        {
            get { return _assest_id; }
            set { _assest_id = value; }
        }

        public string TestName
        {
            get { return _testName; }
            set { _testName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Skill_id{
            get {  return _skill_id; }
            set { _skill_id = value;}
        }

        public override bool Equals(object? obj)
        {
            return obj is AssesmentTest test &&
                   _assest_id == test._assest_id &&
                   _testName == test._testName &&
                   _description == test._description &&
                    _skill_id == test._skill_id &&
                   Assest_id == test.Assest_id &&
                   TestName == test.TestName &&
                   Description == test.Description &&
                   Skill_id == test.Skill_id;
        }
    }
}
