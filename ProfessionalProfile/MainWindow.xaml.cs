using ProfessionalProfile.domain;
using ProfessionalProfile.profile_page;
using ProfessionalProfile.repo;
using ProfessionalProfile.service.login;
using ProfessionalProfile.view;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProfessionalProfile
{
    /// <_summary>
    /// Interaction logic for MainWindow.xaml
    /// </_summary>
    public partial class MainWindow : Window
    {
        UserRepo repo;
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();

            ProfilePage profile = new ProfilePage(4);
            profile.WindowState = WindowState.Maximized; // Set the WindowState to Maximized
            profile.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}