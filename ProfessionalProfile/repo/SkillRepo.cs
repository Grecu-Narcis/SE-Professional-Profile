using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProfessionalProfile.repo
{
    public class SkillRepo : RepoInterface<Skill>
    {
        private string _connectionString;

        public SkillRepo()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(Skill item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC InsertSkill @Name";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Name", item.Name);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC DeleteSkill @SkillId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<Skill> GetAll()
        {
            List<Skill> skills = new List<Skill>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC GetAllSkills";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Skill skill = new Skill(reader.GetInt32(0), reader.GetString(1));
                    skills.Add(skill);
                }
            }

            return skills;
        }

        public List<Skill> GetByUserId(int userId)
        {
            List<Skill> skills = new List<Skill>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC GetUserSkills @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", userId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Skill skill = new Skill(reader.GetInt32(0), reader.GetString(1));
                    skills.Add(skill);
                }
            }

            return skills;
        }

        public Skill GetById(int id)
        {
            Skill skill = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Skills WHERE SkillId = @Id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        int SkillId = (int)reader["SkillId"];
                        string Name = (string)reader["Name"];


                        skill = new Skill(SkillId, Name);
                    }
                }
            }

            return skill;
        }


        public int GetIdByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT SkillId FROM Skills WHERE Name = @Name";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", name);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Convert.ToInt32(reader["SkillId"]);
                    }
                }
            }

            return 0;
        }

        public void Update(Skill item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC UpdateSkill @SkillId = @id, @Name = @name";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", item.SkillId);
                command.Parameters.AddWithValue("@name", item.Name);

                command.ExecuteNonQuery();
            }
        }
    }
}
