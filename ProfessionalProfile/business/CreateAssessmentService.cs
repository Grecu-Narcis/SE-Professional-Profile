using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.business
{
    public class CreateAssessmentService
    {
        private AnswerRepo AnswerRepo { get; }
        private QuestionRepo QuestionRepo { get; }
        private AssessmentTestRepo AssessmentTestRepo { get; }
        private SkillRepo SkillRepo { get; }

        public CreateAssessmentService()
        {
            this.AssessmentTestRepo = new AssessmentTestRepo();
            this.QuestionRepo = new QuestionRepo();
            this.AnswerRepo = new AnswerRepo();
            this.SkillRepo = new SkillRepo();
        }

        public List<Skill> getAllSkills()
        {
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill(1, "Python"));
            skills.Add(new Skill(2, "C++"));

            return skills;
        }

        public void createAssessmentTest(AssessmentTestDTO assessmentTestDTO, int userId)
        {
            int skillId = SkillRepo.GetIdByName(assessmentTestDTO.SkillTested);
            AssessmentTest assessmentTest = new AssessmentTest(0, assessmentTestDTO.TestName, userId, assessmentTestDTO.Description, skillId);

            AssessmentTestRepo.Add(assessmentTest);
            int assessmentTestId = AssessmentTestRepo.GetIdByName(assessmentTestDTO.TestName);

            foreach (QuestionDTO questionDTO in assessmentTestDTO.questions)
            {
                createQuestion(questionDTO, assessmentTestId);
            }
        }

        public void createQuestion(QuestionDTO questionDTO, int assessmentId)
        {
            Question question = new Question(0, questionDTO.QuestionText, assessmentId);
            QuestionRepo.Add(question);
            int questionId = QuestionRepo.GetIdByNameAndAssessmentId(questionDTO.QuestionText, assessmentId);

            foreach (AnswerDTO answerDTO in questionDTO.Answers)
            {
                Answer answer = new Answer(0, answerDTO.AnswerText, questionId, answerDTO.AnswerText == questionDTO.CorrectAnswer.AnswerText);
                AnswerRepo.Add(answer);
            }
        }

    }
}
