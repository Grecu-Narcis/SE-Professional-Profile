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
    class PremiumUsersRepo : RepoInterface<int>
    {
        private string _connectionString;

        public PremiumUsersRepo()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(int item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO isPremium (userId) values (" + item + ")"; ;

                SqlCommand command = new SqlCommand(sql, connection);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<int> GetAll()
        {
            List<int> premiumUsers = new List<int>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM isPremium";

                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int userId = (int)reader["userId"];
                    

                    premiumUsers.Add(userId);
                }
            }

            return premiumUsers;
        }

        public int GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int item)
        {
            throw new NotImplementedException();
        }
    }
}
