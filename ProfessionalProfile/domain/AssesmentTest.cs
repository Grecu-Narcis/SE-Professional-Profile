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
        private string _testCreator;
        private int _skill_id;

        public AssesmentTest(int assest_id, string testName, string testCreator, string description, int _skill_id)
        {
            this._assest_id = assest_id;
            this._testName = testName;
            this._description = description;
            this._skill_id = _skill_id;
            this._testCreator = testCreator;
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

        public int  Skill_id{
            get {  return _skill_id; }
            set { _skill_id = value;}
        }

        public string TestCreator
        {
            get { return this._testCreator; }
            set { this._testCreator = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is AssesmentTest test &&
                   _assest_id == test._assest_id &&
                   _testName == test._testName &&
                   _description == test._description &&
                   _skill_id == test._skill_id &&
                   _testCreator == test._testCreator &&
                   TestCreator == test.TestCreator &&
                   Assest_id == test.Assest_id &&
                   TestName == test.TestName &&
                   Description == test.Description &&
                   Skill_id == test.Skill_id;
        }
    }
}
