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
    public class VolunteeringRepo : RepoInterface<Volunteering>
    {
        private string _connectionString;

        public VolunteeringRepo()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(Volunteering item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC InsertVolunteering @UserId, @Organisation, @Role, @Description";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@UserId", item.UserId);
                command.Parameters.AddWithValue("@Organisation", item.Organisation);
                command.Parameters.AddWithValue("@Role", item.Role);
                command.Parameters.AddWithValue("@Description", item.Description);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC DeleteVolunteering @VolunteeringId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<Volunteering> GetAll()
        {
            List<Volunteering> volunteerings = new List<Volunteering>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC GetAllVolunteerings";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int volunteeringId = (int)reader["VolunteeringId"];
                    int userId = (int)reader["UserId"];
                    string organisation = (string)reader["Organisation"];
                    string role = (string)reader["Role"];
                    string description = (string)reader["Description"];

                    Volunteering volunteering = new Volunteering(volunteeringId, userId, organisation, role, description);
                    volunteerings.Add(volunteering);
                }
            }

            return volunteerings;
        }

        public List<Volunteering> GetByUserId(int userId)
        {
            List<Volunteering> volunteering = new List<Volunteering>();

            volunteering = GetAll();

            for (int i = 0; i < volunteering.Count; i++)
            {
                if (volunteering[i].UserId != userId)
                {
                    volunteering.RemoveAt(i);
                    i--;
                }
            }

            return volunteering;
        }

        public Volunteering GetById(int id)
        {
            Volunteering volunteering = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC GetVolunteeringById @VolunteeringId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    try
                    {
                        int volunteeringId = (int)reader["VolunteeringId"];
                        int userId = (int)reader["UserId"];
                        string organisation = (string)reader["Organisation"];
                        string role = (string)reader["Role"];
                        string description = (string)reader["Description"];

                        volunteering = new Volunteering(volunteeringId, userId, organisation, role, description);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error getting user by ID: {e.Message}");
                    }
                }
            }
            return volunteering;
        }

        public void Update(Volunteering item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"EXEC UpdateVolunteering
                @VolunteeringId = @VolunteeringId,
                @UserId = @UserId,
                @Organisation = @Organisation,
                @Role = @Role,
                @Description = @Description";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@VolunteeringId", item.VolunteeringId);
                command.Parameters.AddWithValue("@UserId", item.UserId);
                command.Parameters.AddWithValue("@Organisation", item.Organisation);
                command.Parameters.AddWithValue("@Role", item.Role);
                command.Parameters.AddWithValue("@Description", item.Description);

                command.ExecuteNonQuery();
            }
        }
    }
}
