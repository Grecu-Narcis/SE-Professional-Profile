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
    public class AssessmentTestRepo : RepoInterface<AssessmentTestRepo>
    {
        private string _connectionString;

        public AssessmentTestRepo()
        {
            // IsRead connection string from app.config
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(AssessmentTestRepo item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC ";
                SqlCommand command = new SqlCommand(sql, connection);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
        }

        public List<AssessmentTestRepo> GetAll()
        {
            List<AssessmentTestRepo> assesmentTests = new List<AssessmentTestRepo>();

            return assesmentTests;
        }

        public AssessmentTestRepo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AssessmentTestRepo item)
        {
        }
    }
}
