using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.business
{
    public class SelectTestService
    {
        private AnswerRepo AnswerRepo { get; }
        private QuestionRepo QuestionRepo { get; }
        private AssessmentTestRepo AssessmentTestRepo { get; }
        private SkillRepo SkillRepo { get; }

        public SelectTestService()
        {
            this.AssessmentTestRepo = new AssessmentTestRepo();
            this.QuestionRepo = new QuestionRepo();
            this.AnswerRepo = new AnswerRepo();
            this.SkillRepo = new SkillRepo();
        }

        public List<AssessmentTest> getAllAssessmentTests()
        {
            return AssessmentTestRepo.GetAll();
        }

        public AssessmentTest getAssessmentByName(string testName)
        {
            int id = AssessmentTestRepo.GetIdByName(testName);
            return AssessmentTestRepo.GetById(id);
        }

        public Skill getSkillById(int id)
        {
            return SkillRepo.GetById(id);
        }
    }
}
