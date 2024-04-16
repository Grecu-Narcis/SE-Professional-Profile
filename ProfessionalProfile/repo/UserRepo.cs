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
    public class UserRepo : RepoInterface<User>
    {
        private string _connectionString;

        public UserRepo()
        {
            // IsRead connection string from app.config
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }
        public void Add(User item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC InsertUser @FirstName, @LastName, @Email, @Password, @Phone, @Summary, @DateOfBirth, @DarkTheme, @Address, @WebsiteURL, @Picture";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@FirstName", item.FirstName);
                command.Parameters.AddWithValue("@LastName", item.LastName);
                command.Parameters.AddWithValue("@Email", item.Email);
                command.Parameters.AddWithValue("@Password", item.Password);
                command.Parameters.AddWithValue("@Phone", item.Phone);
                command.Parameters.AddWithValue("@Summary", item.Summary);
                command.Parameters.AddWithValue("@DateOfBirth", item.DateOfBirth);
                command.Parameters.AddWithValue("@DarkTheme", item.DarkTheme);
                command.Parameters.AddWithValue("@Address", item.Address);
                command.Parameters.AddWithValue("@WebsiteURL", item.WebsiteURL);
                command.Parameters.AddWithValue("@Picture", item.Picture);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC DeleteUser UserId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC GetAllUsers";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userId = (int)reader["UserId"];
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        string email = (string)reader["Email"];
                        string password = (string)reader["Password"]; // Consider hashing password before storing
                        string phone = (string)reader["Phone"];
                        string summary = (string)reader["Summary"];
                        DateTime dateOfBirth = (DateTime)reader["DateOfBirth"];
                        bool darkTheme = (bool)reader["DarkTheme"];
                        string address = (string)reader["Address"];
                        string websiteURL = (string)reader["WebsiteURL"];
                        string picture = (string)reader["Picture"];

                        User user = new User(userId, firstName, lastName, email, password, phone, summary, dateOfBirth, darkTheme, address, websiteURL, picture);
                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public User GetById(int id)
        {
            User user = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Consider using parameterized queries to prevent SQL injection
                string sql = "Select * from Users where UserId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        try
                        {
                            int userId = (int)reader["UserId"];
                            string firstName = (string)reader["FirstName"];
                            string lastName = (string)reader["LastName"];
                            string email = (string)reader["Email"];
                            // **Security:** Don't return password in the retrieved user object
                            string password = null; // Consider hashing password before storing
                            string phone = (string)reader["Phone"];
                            string summary = (string)reader["Summary"];
                            DateTime dateOfBirth = (DateTime)reader["DateOfBirth"];
                            bool darkTheme = (bool)reader["DarkTheme"];
                            string address = (string)reader["Address"];
                            string websiteURL = (string)reader["WebsiteURL"];
                            string picture = (string)reader["Picture"];

                            user = new User(userId, firstName, lastName, email, password, phone, summary, dateOfBirth, darkTheme, address, websiteURL, picture);
                        }
                        catch (Exception ex)
                        {
                            // Handle potential exceptions during data reading (e.g., casting issues)
                            Console.WriteLine($"Error getting user by ID: {ex.Message}");
                        }
                    }
                }
            }

            return user;
        }

        public void Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Consider using parameterized queries to prevent SQL injection
                string sql = @"EXEC UpdateUser
                            UserId = @UserId
                            FirstName = @FirstName,
                            LastName = @LastName,
                            Email = @Email,
                            Phone = @Phone,
                            Summary = @Summary,
                            DateOfBirth = @DateOfBirth,
                            DarkTheme = @DarkTheme,
                            Address = @Address,
                            WebsiteURL = @WebsiteURL,
                            Picture = @Picture";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@UserId", user.UserId);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Phone", user.Phone);
                command.Parameters.AddWithValue("@Summary", user.Summary);
                command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@DarkTheme", user.DarkTheme);
                command.Parameters.AddWithValue("@Address", user.Address);
                command.Parameters.AddWithValue("@WebsiteURL", user.WebsiteURL);
                command.Parameters.AddWithValue("@Picture", user.Picture);

                command.ExecuteNonQuery();
            }
        }
    }
}
