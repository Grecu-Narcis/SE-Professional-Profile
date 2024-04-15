using ProfessionalProfile.business;
using ProfessionalProfile.domain;
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
    /// Interaction logic for SearchUserPage.xaml
    /// </summary>
    /// 

    public partial class SearchUserPage : Window
    {
        private SearchUsersService searchUsersService { get; }
        private int userId;

        public SearchUserPage()
        {
            InitializeComponent();

            this.userId = 1;
            this.searchUsersService = new SearchUsersService(new repo.UserRepo());
        }

        private void SearchUsersButton_Click(object sender, RoutedEventArgs e)
        {
            string searchKey = this.SearchTextBox.Text;
            List<User> matchedUsers = this.getAllMatchedUsers(searchKey);

            foreach(User user in matchedUsers)
            {
                this.UsersListBox.Items.Add(user.FirstName + " " + user.LastName);
            }
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
    }
}
