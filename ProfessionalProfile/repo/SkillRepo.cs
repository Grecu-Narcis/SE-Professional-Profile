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
    public class SkillRepo : RepoInterface<Skill>
    {
        private string _connectionString { get; }

        public SkillRepo()
        {
            this._connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(Skill item)
        {
        }

        public void Delete(int id)
        {
        }

        public List<Skill> GetAll()
        {
            List<Skill> skills = new List<Skill>();
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
        }
    }
}
