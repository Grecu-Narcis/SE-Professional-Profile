using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class Question
    {
        private int _questionId;
        private string _questionText;
        private int _assesmentTestId;

        public Question(int questionId, string questionText, int assesmentTestId)
        {
            _questionId = questionId;
            _questionText = questionText;
            _assesmentTestId = assesmentTestId;
        }

        public int QuestionId{
            get {  return _questionId; }
            set { _questionId = value; }
        }

        public int AssesmentTestId
        {
            get { return _assesmentTestId;}
            set { _assesmentTestId = value;}
        }

        public string QuestionText
        {
            get { return _questionText; }
            set { _questionText = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Question question &&
                   _questionId == question._questionId &&
                   _questionText == question._questionText &&
                   _assesmentTestId == question._assesmentTestId &&
                   QuestionId == question.QuestionId &&
                   AssesmentTestId == question.AssesmentTestId &&
                   QuestionText == question.QuestionText;
        }

        public override string ToString()
        {
            return _questionText;
        }
    }
}
