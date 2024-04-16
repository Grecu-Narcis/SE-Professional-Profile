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
    public class NotificationRepo : RepoInterface<Notification>
    {
        private string _connectionString;

        public NotificationRepo()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(Notification item)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO Notifications (UserId, Activity, Timestamp, Details, isRead) 
                       VALUES (@UserId, @Activity, @Timestamp, @Details, @isRead)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@UserId", item.UserId);
                command.Parameters.AddWithValue("@Activity", item.Activity);
                command.Parameters.AddWithValue("@Timestamp", item.Timestamp);
                command.Parameters.AddWithValue("@Details", item.Details);
                command.Parameters.AddWithValue("@isRead", item.IsRead);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
        }

        public List<Notification> GetAll()
        {
            List<Notification> notifications = new List<Notification>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Notifications";

                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int notificationId = (int)reader["NotificationId"];
                    int userId = (int)reader["UserId"];
                    string activity = (string)reader["Activity"];
                    DateTime timestamp = (DateTime)reader["Timestamp"];
                    string details = (string)reader["Details"];
                    bool isRead = (bool)reader["isRead"];

                    Notification notification = new Notification(notificationId, userId, activity, timestamp, details, isRead);
                    notifications.Add(notification);
                }
            }

            return notifications;
        }

        public List<Notification> getAllByUserId(int userId)
        {
            List<Notification> allNotifications = this.GetAll();

            return allNotifications.FindAll((notification) => notification.UserId == userId);
        }

        public Notification GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Notification item)
        {
        }
    }
}
