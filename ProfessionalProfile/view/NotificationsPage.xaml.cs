using ProfessionalProfile.business;
using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProfessionalProfile.view
{
    /// <summary>
    /// Interaction logic for NotificationsPage.xaml
    /// </summary>
    public partial class NotificationsPage : Window
    {
        NotificationsService notificationsService { get; }
        SearchUsersService SearchUsersService { get; }
        int userId;
        User currentUser { get; set; }

        public NotificationsPage(int userId)
        {
            InitializeComponent();
            this.notificationsService = new NotificationsService(new NotificationRepo());
            this.SearchUsersService = new SearchUsersService(new UserRepo());
            this.userId = userId;
            this.currentUser = SearchUsersService.getUserById(userId);

            this.nameLabel.Content = "Hi, " + currentUser.FirstName + " " + currentUser.LastName;
            this.populateNotifications();
        }

        private void populateNotifications()
        {
            List<Notification> notifications = notificationsService.GetNotifications(userId);

            foreach (Notification notification in notifications)
            {
                this.notificationsList.Items.Add(notification.Activity + " " + notification.Timestamp);
            }
        }
    }
}
