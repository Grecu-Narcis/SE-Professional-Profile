using ProfessionalProfile.business_card_page;
using ProfessionalProfile.domain;
using ProfessionalProfile.profile_page;
using ProfessionalProfile.projects_page;
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

            //ProjectsPage projectsPage = new ProjectsPage(60);
            //projectsPage.Show();

            //BusinessCardPage businessCardPage = new BusinessCardPage(60);
            //businessCardPage.Show();

            LoginPage loginPage = new LoginPage();
            loginPage.Show();

            //ProfilePage profile = new ProfilePage(60, 4);
            //profile.WindowState = WindowState.Maximized; // Set the WindowState to Maximized
            //profile.Show();

            //PrivacySettingsPage privacySettingsPage = new PrivacySettingsPage(60);
            //privacySettingsPage.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}