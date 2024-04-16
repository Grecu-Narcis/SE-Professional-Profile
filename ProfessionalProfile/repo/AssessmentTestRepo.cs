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
    public class AssessmentTestRepo : RepoInterface<AssessmentTest>
    {
        private string _connectionString;

        public AssessmentTestRepo()
        {
            // IsRead connection string from app.config
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(AssessmentTest item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO AssessmentTest (TestName, UserId, Description, SkillId) 
                       VALUES (@Name, @UserId, @Description, @SkillId)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", item.TestName);
                command.Parameters.AddWithValue("@UserId", item.UserId);
                command.Parameters.AddWithValue("@Description", item.Description);
                command.Parameters.AddWithValue("@SkillId", item.Skill_id);

                command.ExecuteNonQuery();
            }
        }

        public int GetIdByName(string testName)
        {
            int assessmentTestId = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT AssessmentTestId FROM AssessmentTest WHERE TestName = @TestName";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TestName", testName);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    assessmentTestId = Convert.ToInt32(result);
                }
            }

            return assessmentTestId;
        }

        public List<AssessmentTest> GetAll()
        {
            List<AssessmentTest> assessmentTests = new List<AssessmentTest>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM AssessmentTest";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int AssessmentTestId = (int)reader["assessmentTestId"];
                        string TestName = (string)reader["testName"];
                        int UserId = (int)reader["userId"];
                        string Description = (string)reader["description"];
                        int SkillId = (int)reader["SkillId"];

                        AssessmentTest assessmentTest = new AssessmentTest(AssessmentTestId, TestName, UserId, Description, SkillId);

                        assessmentTests.Add(assessmentTest);
                    }
                }
            }

            return assessmentTests;
        }


        public void Delete(int id)
        {
        }

        public AssessmentTest GetById(int id)
        {
            AssessmentTest assessmentTest = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM AssessmentTest WHERE assessmentTestId = @Id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        int AssessmentTestId = (int)reader["assessmentTestId"];
                        string TestName = (string)reader["testName"];
                        int UserId = (int)reader["userId"];
                        string Description = (string)reader["description"];
                        int SkillId = (int)reader["SkillId"];

                        assessmentTest = new AssessmentTest(AssessmentTestId, TestName, UserId, Description, SkillId);

                    }
                }
            }

            return assessmentTest;
        }

        public void Update(AssessmentTest item)
        {
        }
    }
}
