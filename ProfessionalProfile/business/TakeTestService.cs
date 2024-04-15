using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.business
{
    public class TakeTestService
    {
        private AnswerRepo AnswerRepo { get; }
        private QuestionRepo QuestionRepo { get; }
        private AssessmentTestRepo AssessmentTestRepo { get; }
        private SkillRepo SkillRepo { get; }
        private AssessmentResultRepo AssessmentResultRepo { get; }

        public TakeTestService()
        {
            this.AssessmentTestRepo = new AssessmentTestRepo();
            this.QuestionRepo = new QuestionRepo();
            this.AnswerRepo = new AnswerRepo();
            this.AssessmentResultRepo = new AssessmentResultRepo();
            this.SkillRepo = new SkillRepo();
        }

        //TODO: get test as dto

        public AssessmentTestDTO getTestDTO(int testId)
        {
            AssessmentTest test = AssessmentTestRepo.GetById(testId);
            List<QuestionDTO> questionDTOs = GetQuestionDTOs(testId);
            Skill skill = SkillRepo.GetById(test.Skill_id);

            return new AssessmentTestDTO(test.TestName, test.Description, questionDTOs, skill.Name);
        }

        public List<QuestionDTO> GetQuestionDTOs(int testId)
        {
            List<QuestionDTO> questionDTOs = new List<QuestionDTO>();
            List<Question> questions = QuestionRepo.getAllByTestId(testId);
            foreach (Question question in questions)
            {
                AnswerDTO correctAnswer = null;

                List<Answer> answers = AnswerRepo.GetAnswers(question.QuestionId);
                List<AnswerDTO> answerDTOs = new List<AnswerDTO>();
                foreach (Answer answer in answers)
                {
                    answerDTOs.Add(new AnswerDTO(answer.AnswerText, answer.IsCorrect));
                    if (answer.IsCorrect)
                    {
                        correctAnswer = new AnswerDTO(answer.AnswerText, answer.IsCorrect);
                    }
                }
                questionDTOs.Add(new QuestionDTO(question.QuestionText, answerDTOs, correctAnswer));
            }

            return questionDTOs;
        }

        public int computeTestResult(AssessmentTestDTO testDTO, List<string> answers)
        {
            int correctAnswers = 0;
            int totalQuestions = testDTO.questions.Count;

            for (int i = 0; i < totalQuestions; i++)
            {
                QuestionDTO questionDTO = testDTO.questions[i];

                if (answers[i] == questionDTO.CorrectAnswer.AnswerText)
                    correctAnswers++;
            }


            int score = (correctAnswers * 100) / totalQuestions;
            return score;
        }

        public void addTestResult(int testId, int userId, int score, DateTime testDate)
        {
            AssessmentResult assessmentResult = new AssessmentResult(0, testId, userId, score, testDate);

            AssessmentResultRepo.Add(assessmentResult);
        }
    }
}
