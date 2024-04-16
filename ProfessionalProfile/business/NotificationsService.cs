using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.business
{
    class NotificationsService
    {
        NotificationRepo NotificationRepo { get; }

        public NotificationsService(NotificationRepo notificationRepo)
        {
            this.NotificationRepo = notificationRepo;
        }

        public List<Notification> GetNotifications(int userId)
        {
            List<Notification> notifications = this.NotificationRepo.getAllByUserId(userId);

            notifications.Sort((firstNotification, secondNotification) =>
            {
                return secondNotification.Timestamp.CompareTo(firstNotification.Timestamp);
            });

            return notifications;
        }

        public void AddNotification(Notification notification)
        {
            NotificationRepo.Add(notification);
        }
    }
}
