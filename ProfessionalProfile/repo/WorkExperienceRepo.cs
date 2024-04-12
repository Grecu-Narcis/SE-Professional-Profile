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
    public class WorkExperienceRepo : RepoInterface<WorkExperience>
    {
        private string _connectionString;

        public WorkExperienceRepo()
        {
            // IsRead connection string from app.config
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(WorkExperience item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC InsertWorkExperience @UserId, @JobTitle, @Company, @Location, @EmployementPeriod, @Responsibilities, @Achievements, @Description";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@JobTitle", item.JobTitle);
                command.Parameters.AddWithValue("@Company", item.Company);
                command.Parameters.AddWithValue("@Location", item.Location);
                command.Parameters.AddWithValue("@EmployementPeriod", item.EmployementPeriod);
                command.Parameters.AddWithValue("@Responsibilities", item.Responsibilities);
                command.Parameters.AddWithValue("@Achievements", item.Achievements);
                command.Parameters.AddWithValue("@Description", item.Description);
                command.Parameters.AddWithValue("@UserId", item.User_id);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
        }

        public List<WorkExperience> GetAll()
        {
            throw new NotImplementedException();
        }

        public WorkExperience GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(WorkExperience item)
        {
        }
    }
}
