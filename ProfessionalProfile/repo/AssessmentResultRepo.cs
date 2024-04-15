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
    internal class AssessmentResultRepo : RepoInterface<AssessmentResult>
    {
        private string _connectionString;

        public AssessmentResultRepo()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(AssessmentResult item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO AssessmentResult (AssessmentTestId, Score, UserId, TestDate) " +
                             "VALUES (@AssessmentTestId, @Score, @UserId, @TestDate)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@AssessmentTestId", item.AssessmentTestId);
                command.Parameters.AddWithValue("@Score", item.Score);
                command.Parameters.AddWithValue("@UserId", item.UserId);
                command.Parameters.AddWithValue("@TestDate", item.TestDate);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            
        }

        public List<AssessmentResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public AssessmentResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AssessmentResult item)
        {
            
        }
    }
}
