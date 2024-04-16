using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class Answer
    {
        private int _answerId;
        private string _answerText;
        private int _questionId;
        private bool _isCorrect;
        

        public Answer(int answerId, string answerText, int questionId,  bool isCorrect)
        {
            _answerId = answerId;
            _questionId = questionId;
            _answerText = answerText;
            _isCorrect = isCorrect;
        }

        public int AnswerId
        {
            get { return _answerId; }
            set {  _answerId = value; }
           }

        public int QuestionId
        {
            get { return _questionId; }
            set { _questionId = value; }
        }

        public string AnswerText
        {
            get { return _answerText; }
            set { _answerText = value; }
        }

        public bool IsCorrect
        { get { return _isCorrect; } set { _isCorrect = value; } }

        public override bool Equals(object? obj)
        {
            return obj is Answer answer &&
                   _answerId == answer._answerId &&
                   _questionId == answer._questionId &&
                   _answerText == answer._answerText &&
                   _isCorrect == answer._isCorrect &&
                   AnswerId == answer.AnswerId &&
                   QuestionId == answer.QuestionId &&
                   AnswerText == answer.AnswerText &&
                   IsCorrect == answer.IsCorrect;
        }

    }
}
