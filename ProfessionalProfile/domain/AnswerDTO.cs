using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class AnswerDTO
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }


        public AnswerDTO(string answerText, bool isCorrect)
        {
            AnswerText=answerText;
            IsCorrect=isCorrect;
        }
    }
}
