using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class QuestionDTO
    {
        public String QuestionText { get; set; }
        public List<AnswerDTO> Answers { get; set; }
        public AnswerDTO CorrectAnswer { get; set; }

        public QuestionDTO(string questionText, List<AnswerDTO> answers, AnswerDTO correctAnswer)
        {
            QuestionText = questionText;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
    }
}
