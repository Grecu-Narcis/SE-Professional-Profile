using ProfessionalProfile.domain;
using ProfessionalProfile.SectionValidators;
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
            SectionValidator.validateWorkExperience(item);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC InsertWorkExperience @UserId, @JobTitle, @Company, @Location, @EmploymentPeriod, @Responsibilities, @Achievements, @Description";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@JobTitle", item.JobTitle);
                command.Parameters.AddWithValue("@Company", item.Company);
                command.Parameters.AddWithValue("@Location", item.Location);
                command.Parameters.AddWithValue("@EmploymentPeriod", item.EmploymentPeriod);
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
                        string jobTitle = (string)reader["JobTitle"];
                        string company = (string)reader["Company"];
                        string location = (string)reader["Location"];
                        string employmentPeriod = (string)reader["EmploymentPeriod"];
                        string responsibilities = (string)reader["Responsibilities"];
                        string achievements = (string)reader["Achievements"];
                        string description = (string)reader["Description"];
                        int userId = (int)reader["UserId"];

                        WorkExperience workExperience = new WorkExperience(workId, userId, jobTitle, company, location, employmentPeriod, responsibilities, achievements, description);
                        workExperiences.Add(workExperience);
                    }
                }
            }

            return workExperiences;
        }

        public List<WorkExperience> GetByUserId(int userId)
        {
            List<WorkExperience> experiences = new List<WorkExperience>();

            experiences = GetAll();

            for (int i = 0; i < experiences.Count; i++)
            {
                if (experiences[i].UserId != userId)
                {
                    experiences.RemoveAt(i);
                    i--;
                }
            }

            return experiences;
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
                            int userId = (int)reader["UserId"];
                            string jobTitle = (string)reader["JobTitle"];
                            string company = (string)reader["Company"];
                            string location = (string)reader["Location"];
                            string achievements = (string)reader["Achievements"];
                            string description = (string)reader["Description"];
                            string responsibilities = (string)reader["Responsibilities"];
                            string employmentPeriod = (string)reader["EmploymentPeriod"];

                            workExperience = new WorkExperience(workId, userId, jobTitle, company, location, employmentPeriod, responsibilities, achievements, description);
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
            SectionValidator.validateWorkExperience(item);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"EXEC UpdateWorkExperience
                @WorkId = @workId,
                @UserId = @userId,
                @JobTitle = @jobTitle,
                @Company = @company,
                @Location = @location,
                @EmploymentPeriod = @employmentPeriod,
                @Responsibilities = @responsibilities,
                @Achievements = @achievements,
                @Description = @description";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@workId", item.WorkId);
                command.Parameters.AddWithValue("@jobTitle", item.JobTitle);
                command.Parameters.AddWithValue("@company", item.Company);
                command.Parameters.AddWithValue("@location", item.Location);
                command.Parameters.AddWithValue("@employmentPeriod", item.EmploymentPeriod);
                command.Parameters.AddWithValue("@responsibilities", item.Responsibilities);
                command.Parameters.AddWithValue("@achievements", item.Achievements);
                command.Parameters.AddWithValue("@description", item.Description);
                command.Parameters.AddWithValue("@userId", item.UserId);

                command.ExecuteNonQuery();
            }
        }
    }
}