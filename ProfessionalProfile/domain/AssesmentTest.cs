using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    class AssesmentTest
    {
        private int _assest_id;
        private string _testName;
        private string _description;
        private List<Skill> _skillsAssessed;

        public AssesmentTest(int assest_id, string testName, string description, List<Skill> skillsAssessed)
        {
            this._assest_id = assest_id;
            this._testName = testName;
            this._description = description;
            this._skillsAssessed = skillsAssessed;
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

        public List<Skill> SkillsAssessed{
            get {  return _skillsAssessed; }
            set { _skillsAssessed = value;}
        }

        public override bool Equals(object? obj)
        {
            return obj is AssesmentTest test &&
                   _assest_id == test._assest_id &&
                   _testName == test._testName &&
                   _description == test._description &&
                   EqualityComparer<List<Skill>>.Default.Equals(_skillsAssessed, test._skillsAssessed) &&
                   Assest_id == test.Assest_id &&
                   TestName == test.TestName &&
                   Description == test.Description &&
                   EqualityComparer<List<Skill>>.Default.Equals(SkillsAssessed, test.SkillsAssessed);
        }
    }
}
