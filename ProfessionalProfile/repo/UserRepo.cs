using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class UserRepo : RepoInterface<User>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public void Add(User item)
        {
        }

        public void Delete(int id)
        {
        }

        public User Get(int id)
        {
            User user = new User();
            return user;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            
            // Implement logic to call the GetAllUsers procedure using a SqlCommand and populate a list of User objects
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string procedureName = "GetAllUsers";
                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        users.Add(new User(reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetDateTime(7),
                            reader.GetBoolean(8),
                            reader.GetString(9),
                            reader.GetString(10),
                            reader.GetString(11)
                            ));
                }
            }

            return users;
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
