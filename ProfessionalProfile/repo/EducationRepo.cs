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
    public class EducationRepo : RepoInterface<Education>
    {
        private string _connectionString;

        public EducationRepo()
        {
            this._connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(Education item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC InsertEducation @UserId, @Degree, @Institution, @FieldOfStudy, @GraduationDate, @GPA";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@UserId", item.UserId);
                command.Parameters.AddWithValue("@Degree", item.Degree);
                command.Parameters.AddWithValue("@Institution", item.Institution);
                command.Parameters.AddWithValue("@FieldOfStudy", item.FieldOfStudy);
                command.Parameters.AddWithValue("@GraduationDate", item.GraduationDate);
                command.Parameters.AddWithValue("@GPA", item.GPA);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC DeleteEducation @EducationId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<Education> GetAll()
        {
            List<Education> educations = new List<Education>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "Exec GetAllEducations";   
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int educationId = (int)reader["EducationId"];
                        int userId = (int)reader["UserId"];
                        string degree = (string)reader["Degree"];
                        string institution = (string)reader["Institution"];
                        string fieldOfStudy = (string)reader["FieldOfStudy"];
                        DateTime graduationDate = (DateTime)reader["GraduationDate"];
                        double GPA = (double)reader["GPA"];

                        Education education = new Education(educationId, userId, degree, institution, fieldOfStudy, graduationDate, GPA);
                        educations.Add(education);
                    }
                }
            }

           return educations;
        }

        public Education GetById(int id)
        {
            Education education = null;

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC GetEducationById @EducationId = @id";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        try
                        {
                            int educationId = (int)reader["EducationId"];
                            int userId = (int)reader["UserId"];
                            string degree = (string)reader["Degree"];
                            string institution = (string)reader["Institution"];
                            string fieldOfStudy = (string)reader["FieldOfStudy"];
                            DateTime graduationDate = (DateTime)reader["GraduationDate"];
                            double GPA = (double)reader["GPA"];

                            education = new Education(educationId, userId, degree, institution, fieldOfStudy, graduationDate, GPA);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error getting user by ID: {ex.Message}");
                        }
                    }
                }
            }
            return education;
        }

        public void Update(Education item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC UpdateEducation @EducationId, @UserId, @Degree, @Institution, @FieldOfStudy, @GraduationDate, @GPA";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@EducationId", item.EducationId);
                command.Parameters.AddWithValue("@UserId", item.UserId);
                command.Parameters.AddWithValue("@Degree", item.Degree);
                command.Parameters.AddWithValue("@Institution", item.Institution);
                command.Parameters.AddWithValue("@FieldOfStudy", item.FieldOfStudy);
                command.Parameters.AddWithValue("@GraduationDate", item.GraduationDate);
                command.Parameters.AddWithValue("@GPA", item.GPA);

                command.ExecuteNonQuery();
            }
        }
    }
}
