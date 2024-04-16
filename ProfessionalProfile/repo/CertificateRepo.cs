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
    public class CertificateRepo : RepoInterface<Certificate>
    {
        private string _connectionString;

        public CertificateRepo()
        {
            // IsRead connection string from app.config
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }
        public void Add(Certificate item)
        {
            SectionValidator.validateCertificate(item);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC InsertCertificate @UserId, @Name, @Description, @IssuedBy, @IssuedDate, @ExpirationDate";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Name", item.Name);
                command.Parameters.AddWithValue("@Description", item.Description);
                command.Parameters.AddWithValue("@IssuedBy", item.IssuedBy); // Assuming IssuingOrganisation maps to IssuedBy field
                command.Parameters.AddWithValue("@IssuedDate", item.IssuedDate);
                command.Parameters.AddWithValue("@ExpirationDate", item.ExpirationDate);
                command.Parameters.AddWithValue("@UserId", item.UserId);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int certificateId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC DeleteCertificate @CertificateId = @id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", certificateId);

                command.ExecuteNonQuery();
            }
        }

        public List<Certificate> GetAll()
        {
            List<Certificate> certificates = new List<Certificate>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "EXEC GetAllCertificates";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int certificateId = (int)reader["CertificateId"];
                        string name = (string)reader["Name"];
                        string issuedBy = (string)reader["IssuedBy"];
                        string description = (string)reader["Description"];
                        DateTime issuedDate = (DateTime)reader["IssuedDate"];
                        DateTime expirationDate = (DateTime)reader["ExpirationDate"];
                        int userId = (int)reader["UserId"];

                        Certificate cert = new Certificate(certificateId, userId, name, issuedBy, description, issuedDate, expirationDate);
                        certificates.Add(cert);
                    }
                }
            }
            return certificates;
        }

        public List<Certificate> GetByUserId(int userId)
        {
            List<Certificate> certificates = new List<Certificate>();

            certificates = GetAll();

            for (int i = 0; i < certificates.Count; i++)
            {
                if (certificates[i].UserId != userId)
                {
                    certificates.RemoveAt(i);
                    i--;
                }
            }

            return certificates;
        }

        public Certificate GetById(int id)
        {
            Certificate certificate = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Consider using parameterized queries to prevent SQL injection
                string sql = "EXEC GetCertificateById @CertificateId = @id";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        try
                        {
                            int certificateId = (int)reader["CertificateId"];
                            string name = (string)reader["Name"];
                            string issuedBy = (string)reader["IssuedBy"];
                            string description = (string)reader["Description"];
                            DateTime issuedDate = (DateTime)reader["IssuedDate"];
                            DateTime expirationDate = (DateTime)reader["ExpirationDate"];
                            int userId = (int)reader["UserId"];

                            certificate = new Certificate(certificateId, userId, name, issuedBy, description, issuedDate, expirationDate);
                        }
                        catch (Exception ex)
                        {
                            // Handle potential exceptions during data reading (e.g., casting issues)
                            Console.WriteLine($"Error getting user by ID: {ex.Message}");
                        }
                    }
                }
            }
            return certificate;
        }

        public void Update(Certificate item)
        {
            SectionValidator.validateCertificate(item);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Consider using parameterized queries to prevent SQL injection
                string sql = @"EXEC UpdateCertificate
                @CertificateId = @CertificateId,
                @UserId = @UserId,
                @Name = @Name,
                @Description = @Description,
                @IssuedBy = @IssuedBy,
                @IssuedDate = @IssuedDate,
                @ExpirationDate = @ExpirationDate";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@CertificateId", item.CertificateId);
                command.Parameters.AddWithValue("@UserId", item.UserId);
                command.Parameters.AddWithValue("@Name", item.Name);
                command.Parameters.AddWithValue("@Description", item.Description);
                command.Parameters.AddWithValue("@IssuedBy", item.IssuedBy);
                command.Parameters.AddWithValue("@IssuedDate", item.IssuedDate);
                command.Parameters.AddWithValue("@ExpirationDate", item.ExpirationDate);

                command.ExecuteNonQuery();
            }
        }
    }
}
