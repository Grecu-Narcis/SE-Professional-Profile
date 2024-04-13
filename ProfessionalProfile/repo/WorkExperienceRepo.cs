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
                command.Parameters.AddWithValue("@UserId", item.UserId);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC DeleteWorkExperience @WorkId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<WorkExperience> GetAll()
        {
            List<WorkExperience> workExperiences = new List<WorkExperience>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC GetAllWorkExperiences";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int workId = (int)reader["WorkId"];
                        string jobTitle = (string)reader["JobTitle"].ToString();
                        string company = (string)reader["Company"].ToString();
                        string location = (string)reader["Location"].ToString();
                        string employementPeriod = (string)reader["EmployementPeriod"].ToString();
                        string responsibilities = (string)reader["Responsibilities"].ToString();
                        string achievements = (string)reader["Achievements"].ToString();
                        string description = (string)reader["Description"].ToString();
                        int userId = (int)reader["UserId"];

                        WorkExperience workExperience = new WorkExperience(workId, userId, jobTitle, company, location, employementPeriod, responsibilities, achievements, description);
                        workExperiences.Add(workExperience);
                    }
                }
            }

            return workExperiences;
        }

        public WorkExperience GetById(int id)
        {
            WorkExperience workExperience = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC GetWorkExperienceById @WorkId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        try
                        {
                            int workId = (int)reader["WorkId"];
                            string jobTitle = (string)reader["JobTitle"].ToString();
                            string company = (string)reader["Company"].ToString();
                            string location = (string)reader["Location"].ToString();
                            string employementPeriod = (string)reader["EmployementPeriod"].ToString();
                            string responsibilities = (string)reader["Responsibilities"].ToString();
                            string achievements = (string)reader["Achievements"].ToString();
                            string description = (string)reader["Description"].ToString();
                            int userId = (int)reader["UserId"];

                            workExperience = new WorkExperience(workId, userId, jobTitle, company, location, employementPeriod, responsibilities, achievements, description);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error getting work experience by id: {ex.Message}");
                        }

                    }
                }
            }
            return workExperience;
        }

        public void Update(WorkExperience item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC UpdateWorkExperience @WorkId = @workId, @UserId = @userId, @JobTitle = @jobTitle, @Company = @company, @Location = @location, @EmployementPeriod = @employementPeriod, @Responsibilities = @responsibilities, @Achievements = @achievements, @Description = @description";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@workId", item.WorkId);
                command.Parameters.AddWithValue("@jobTitle", item.JobTitle);
                command.Parameters.AddWithValue("@company", item.Company);
                command.Parameters.AddWithValue("@location", item.Location);
                command.Parameters.AddWithValue("@employementPeriod", item.EmployementPeriod);
                command.Parameters.AddWithValue("@responsibilities", item.Responsibilities);
                command.Parameters.AddWithValue("@achievements", item.Achievements);
                command.Parameters.AddWithValue("@description", item.Description);
                command.Parameters.AddWithValue("@userId", item.UserId);

                command.ExecuteNonQuery();
            }
        }
    }
}