using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class AnswerRepo : RepoInterface<Answer>
    {
        private string _connectionString;

        public AnswerRepo()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }


        public void Add(Answer item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO Answers (AnswerText, QuestionId, IsCorrect) 
                       VALUES (@AnswerText, @QuestionId, @IsCorrect)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@AnswerText", item.AnswerText);
                command.Parameters.AddWithValue("@QuestionId", item.QuestionId);
                command.Parameters.AddWithValue("@IsCorrect", item.IsCorrect);

                command.ExecuteNonQuery();
            }
        }

        public List<Answer> GetAnswers(int questionId)
        {
            List<Answer> answers = new List<Answer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Answers WHERE QuestionId = @QuestionId";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@QuestionId", questionId);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int answerID = (int)reader["AnswerId"];
                    string answerText = (string)reader["AnswerText"];
                    int questionID = (int)reader["QuestionId"];
                    bool isCorrect = (bool)reader["IsCorrect"];

                    answers.Add(new Answer(answerID, answerText, questionID, isCorrect));
                }
            }

            return answers;
        }


        public void Delete(int id)
        {
        }

        public List<Answer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Answer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Answer item)
        {
           
        }
    }
}
