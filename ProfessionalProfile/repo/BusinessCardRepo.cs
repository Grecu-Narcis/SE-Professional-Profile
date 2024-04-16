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
    internal class BusinessCardRepo : RepoInterface<BussinesCard>
    {
        private string _connectionString;

        public BusinessCardRepo()
        {
            // IsRead connection string from app.config
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(BussinesCard item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC InsertBusinessCard @UserId, @Summary, @UniqueUrl";
                SqlCommand command = new SqlCommand(sql, connection);
                
                command.Parameters.AddWithValue("@UserId", item.UserId);
                command.Parameters.AddWithValue("@Summary", item.Summary);
                command.Parameters.AddWithValue("@UniqueUrl", item.UniqueUrl);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC DeleteBusinessCard BCId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<BussinesCard> GetAll()
        {
            List<BussinesCard> bussinesCards = new List<BussinesCard>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC GetAllBusinessCards";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int bcId = (int)reader["BCId"];
                        string summary = (string)reader["Summary"];
                        string uniqueUrl = (string)reader["UniqueUrl"];
                        int userId = (int)reader["UserId"];
                        
                        BussinesCard bussinesCard = new BussinesCard(bcId, summary, uniqueUrl, userId, new List<Skill>());
                        bussinesCards.Add(bussinesCard);
                    }
                }
            }

            return bussinesCards;
        }

        public BussinesCard GetById(int id)
        {
            BussinesCard bussinesCard = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Consider using parameterized queries to prevent SQL injection
                string sql = "Select * from BusinessCard where BCId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        try
                        {
                            int bcId = (int)reader["BCId"];
                            string summary = (string)reader["Summary"];
                            string uniqueUrl = (string)reader["UniqueUrl"];
                            int userId = (int)reader["UserId"];

                            bussinesCard = new BussinesCard(bcId, summary, uniqueUrl, userId, new List<Skill>());
                        }
                        catch (Exception ex)
                        {
                            // Handle potential exceptions during data reading (e.g., casting issues)
                            Console.WriteLine($"Error getting business card by ID: {ex.Message}");
                        }
                    }
                }
            }

            return bussinesCard;
        }

        public BussinesCard GetByUserId(int userId)
        {
            BussinesCard bussinesCard = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Consider using parameterized queries to prevent SQL injection
                string sql = "Select * from BusinessCard where UserId = @userId";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@userId", userId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        try
                        {
                            int bcId = (int)reader["BCId"];
                            string summary = (string)reader["Summary"];
                            string uniqueUrl = (string)reader["UniqueUrl"];

                            bussinesCard = new BussinesCard(bcId, summary, uniqueUrl, userId, new List<Skill>());
                        }
                        catch (Exception ex)
                        {
                            // Handle potential exceptions during data reading (e.g., casting issues)
                            Console.WriteLine($"Error getting business card by user ID: {ex.Message}");
                        }
                    }
                }
            }

            return bussinesCard;
        }

        public void Update(BussinesCard item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Consider using parameterized queries to prevent SQL injection
                string sql = @"EXEC UpdateBusinessCard
                                BCId = @BCId,
                                Summary = @Summary,
                                UniqueUrl = @UniqueUrl,
                                UserId = @UserId";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("BCId", item.BcId);
                command.Parameters.AddWithValue("Summary", item.Summary);
                command.Parameters.AddWithValue("UniqueUrl", item.UniqueUrl);
                command.Parameters.AddWithValue("UserId", item.UserId);

                command.ExecuteNonQuery();
            }
        }

        public List<string> GetBusinessCardSkills(int bcId)
        {
            List<string> skills = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC GetSkillsByBusinessCardId @BCId";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@BCId", bcId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int skillId = (int)reader["SkillId"];
                        string skillName = (string)reader["SkillName"];

                        Skill skill = new Skill(skillId, skillName);
                        skills.Add(skillName);
                    }
                }
            }

            return skills;
        }
    }
}
