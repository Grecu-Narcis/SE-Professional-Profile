using ProfessionalProfile.business;
using ProfessionalProfile.domain;
using ProfessionalProfile.profile_page;
using ProfessionalProfile.repo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SearchUserPage.xaml
    /// </summary>
    /// 

    public class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ListItem(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }

    public partial class SearchUserPage : Window
    {
        private SearchUsersService searchUsersService { get; }
        private NotificationsService NotificationsService { get; }
        private int userId;

        public ObservableCollection<ListItem> Users { get; set; }

        public SearchUserPage(int userId)
        {
            InitializeComponent();

            this.userId = userId;
            this.searchUsersService = new SearchUsersService(new repo.UserRepo());
            this.NotificationsService = new NotificationsService(new NotificationRepo());
            Users = new ObservableCollection<ListItem>();
        }

        private void SearchUsersButton_Click(object sender, RoutedEventArgs e)
        {
            this.UsersListBox.ItemsSource = null;

            string searchKey = this.SearchTextBox.Text;
            List<User> matchedUsers = this.getAllMatchedUsers(searchKey);

            Users = new ObservableCollection<ListItem>();

            if (matchedUsers.Count == 0)
            {
                Users.Add(new ListItem(-1, "No users found"));
                this.UsersListBox.ItemsSource = Users;
                this.ViewProfileButton.IsEnabled = false;
                return;
            }

            foreach(User user in matchedUsers)
            {
                Users.Add(new ListItem(user.UserId, user.FirstName + " " + user.LastName));
            }

            this.UsersListBox.ItemsSource = Users;
            this.ViewProfileButton.IsEnabled = true;
        }

        private List<User> getAllMatchedUsers(string searchString)
        {
            return this.searchUsersService.SearchUsers(searchString, this.userId);
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.Text = "";
        }

        private void ViewProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ListItem selectedUser = (ListItem)this.UsersListBox.SelectedItem;
            User user = this.searchUsersService.getUserById(this.userId);

            Notification profileViewNotification = new Notification(0, selectedUser.Id, user.FirstName + " " + user.LastName + " viewed your profile!", DateTime.Now, "Profile visited", true);
            this.NotificationsService.AddNotification(profileViewNotification);

            ProfilePage profilePage = new ProfilePage(this.userId, selectedUser.Id);
            profilePage.Show();
            this.Close();
        }
    }
}
