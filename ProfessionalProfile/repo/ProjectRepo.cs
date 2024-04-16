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
    public class ProjectRepo : RepoInterface<Project>
    {
        private string _connectionString;

        public ProjectRepo()
        {
            // IsRead connection string from app.config
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(Project item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int userIdInt = int.Parse(item.UserId);

                string sql = "EXEC InsertProject @ProjectName, @Description, @Technologies, @UserId";
                SqlCommand command = new SqlCommand(sql, connection);
                
                command.Parameters.AddWithValue("@ProjectName", item.ProjectName);
                command.Parameters.AddWithValue("@Description", item.Description);
                command.Parameters.AddWithValue("@Technologies", item.Technologies);
                command.Parameters.AddWithValue("@UserId", userIdInt);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC DeleteProject ProjectId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<Project> GetAll()
        {
            List<Project> projects = new List<Project>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC GetAllProjects";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int projectId = (int)reader["ProjectId"];
                        string projectName = (string)reader["ProjectName"];
                        string description = (string)reader["Description"];
                        string technologies = (string)reader["Technologies"];
                        int userId = (int)reader["UserId"];

                        Project project = new Project(projectId, projectName, description, technologies, userId.ToString());
                        projects.Add(project);
                    }
                }
            }

            return projects;
        }

        public Project GetById(int id)
        {
            Project project = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Consider using parameterized queries to prevent SQL injection
                string sql = "Select * from Projects where ProjectId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        try
                        {
                            int projectId = (int)reader["ProjectId"];
                            string projectName = (string)reader["ProjectName"];
                            string description = (string)reader["Description"];
                            string technologies = (string)reader["Technologies"];
                            string userId = reader["UserId"].ToString();
                            

                            project = new Project(projectId, projectName, description, technologies, userId);
                        }
                        catch (Exception ex)
                        {
                            // Handle potential exceptions during data reading (e.g., casting issues)
                            Console.WriteLine($"Error getting project by ID: {ex.Message}");
                        }
                    }
                }
            }

            return project;
        }

        public void Update(Project item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Consider using parameterized queries to prevent SQL injection
                string sql = @"EXEC UpdateProjects
                            ProjectId = @ProjectId,
                            ProjectName = @ProjectName,
                            Description = @Description,
                            Technologies = @Technologies,
                            UserId = @UserId";
                            
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ProjectId", item.ProjectId);
                command.Parameters.AddWithValue("@ProjectName", item.ProjectName);
                command.Parameters.AddWithValue("@Description", item.Description);
                command.Parameters.AddWithValue("@Technologies", item.Technologies);
                command.Parameters.AddWithValue("@UserId", item.UserId);

                command.ExecuteNonQuery();
            }
        }

        public List<Project> GetByUserId(int userId)
        {
            List<Project> projects = new List<Project>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT Projects.* FROM Projects JOIN Users ON Projects.UserId = Users.UserId WHERE Users.UserId = @UserId;";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@UserId", userId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int projectId = (int)reader["ProjectId"];
                        string projectName = (string)reader["ProjectName"];
                        string description = (string)reader["Description"];
                        string technologies = (string)reader["Technologies"];
                        int userIdInt = (int)reader["UserId"];

                        Project project = new Project(projectId, projectName, description, technologies, userIdInt.ToString());
                        projects.Add(project);
                    }
                }
            }

            return projects;
        }
    }
}
