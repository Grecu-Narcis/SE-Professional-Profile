using ProfessionalProfile.business;
using ProfessionalProfile.business_card_page;
using ProfessionalProfile.domain;
using ProfessionalProfile.projects_page;
using ProfessionalProfile.repo;
using ProfessionalProfile.SectionViews;
using ProfessionalProfile.view;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ProfessionalProfile.profile_page
{
    public class ButtonVisibilityMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Ensure both values are provided and are of type int
            if (values != null && values.Length == 2 && values[0] is int userId && values[1] is int currentUserId)
            {
                // Compare the UserId and CurrentUserId
                return userId == currentUserId ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }

            return System.Windows.Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class EndorseButtonVisibilityMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Ensure both values are provided and are of type int
            if (values != null && values.Length == 2 && values[0] is int userId && values[1] is int currentUserId)
            {
                // Compare the UserId and CurrentUserId
                return userId != currentUserId ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }

            return System.Windows.Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public partial class ProfilePage : Window
    {
        
        UserRepo usersRepo = new UserRepo();
       
        public ProfilePage(int userVisitingId, int UserProfileId)
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized;

            if (userVisitingId != UserProfileId)
            {
                ViewNotificationsButton.Visibility = Visibility.Hidden;
                createAssessmentButton.Visibility = Visibility.Hidden;
                takeAssessmentButton.Visibility = Visibility.Hidden;
                becomePremiumUserButton.Visibility = Visibility.Hidden;
                SearchPageButton.Visibility = Visibility.Hidden;
                settingsButton.Visibility = Visibility.Hidden;

                setPrivacy(UserProfileId);
            }

            if (userVisitingId == UserProfileId)
            {
                PremiumUsersService premiumUsersService = new PremiumUsersService();
                bool isPremium = premiumUsersService.isPremiumUser(UserProfileId);

                if (isPremium)
                {
                    becomePremiumUserButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    createAssessmentButton.Visibility = Visibility.Hidden;
                }
            }

            // Populate sample data we will fetch this from the user object later
            CurrentUserId = userVisitingId; // this will be fetched from the logged in user
            this.UserId = UserProfileId;
            User user = usersRepo.GetById(UserId);
            UserName = user.FirstName + " " + user.LastName;
            Email = user.Email;
            Summary = user.Summary;

            // Fetch the user's education, experience, certifications, skills, and volunteering
            EducationRepo = new EducationRepo();
            Education = EducationRepo.GetByUserId(UserId);
            ExperienceRepo = new WorkExperienceRepo();
            Experience = ExperienceRepo.GetByUserId(UserId);
            CertificationsRepo = new CertificateRepo();
            Certifications = CertificationsRepo.GetByUserId(UserId);
            SkillsRepo = new SkillRepo();
            Skills = SkillsRepo.GetByUserId(UserId);
            VolunteeringRepo = new VolunteeringRepo();
            Volunteering = VolunteeringRepo.GetByUserId(UserId);

            // Set the DataContext to this instance
            DataContext = this;
        }

        private void setPrivacy(int userId)
        {
            PrivacyService privacyService = new PrivacyService();

            Privacy userPrivacySettings = privacyService.GetPrivacy(userId);

            if (!userPrivacySettings.canViewEducation)
            {
                this.educationPanel.Visibility = Visibility.Hidden;
                this.educationBorder.Visibility = Visibility.Hidden;
            }

            if (!userPrivacySettings.canViewWorkExperience)
            {
                this.experiencePanel.Visibility = Visibility.Hidden;
                this.experienceBorder.Visibility = Visibility.Hidden;
            }

            if (!userPrivacySettings.canViewCertificates)
            {
                this.certificationsPanel.Visibility = Visibility.Hidden;
                this.certificationsBorder.Visibility = Visibility.Hidden;
            }

            if (!userPrivacySettings.canViewSkills)
            {
                this.skillsPanel.Visibility = Visibility.Hidden;
                this.skillsBorder.Visibility = Visibility.Hidden;
            }

            if (!userPrivacySettings.canViewVolunteering)
            {
                this.volunteeringPanel.Visibility = Visibility.Hidden;
                this.volunteeringBorder.Visibility = Visibility.Hidden;
            }
        }

        private void AddEducationButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the page for adding education
            EducationWindow educationWindow = new EducationWindow(UserId);
            this.Hide();

            educationWindow.ShowDialog();

            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.Show();
            this.Close();
        }

        private void AddExperienceButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the page for adding experience
            WorkExperienceWindow workExperienceWindow = new WorkExperienceWindow(UserId);
            workExperienceWindow.ShowDialog();

            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.Show();
            this.Close();
        }

        private void AddCertificationButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the page for adding certification
            CertificateWindow certificateWindow = new CertificateWindow(UserId);
            certificateWindow.ShowDialog();

            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.Show();
            this.Close();
        }

        private void AddSkillsButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the page for adding skills
            SkillWindow skillWindow = new SkillWindow(UserId);
            skillWindow.ShowDialog();

            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.Show();
            this.Close();
        }

        private void AddVolunteeringButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the page for adding volunteering
            VolunteeringWindow volunteeringWindow = new VolunteeringWindow(UserId);
            volunteeringWindow.ShowDialog();

            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.Show();
            this.Close();
        }

        private void EditEducationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string educationId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the education ID
            int id = int.Parse(educationId);

            EditEducationWindow editEducationWindow = new EditEducationWindow(UserId, id);
            editEducationWindow.ShowDialog();
            // Call a method to edit the education item using the educationId

            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.Show();
            this.Close();
        }
        private void DeleteEducationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string educationId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the education ID
            int id = int.Parse(educationId);

            // Call a method to delete the education item using the educationId
            EducationRepo.Delete(id);

            ProfilePage profilePage = new ProfilePage(this.CurrentUserId, this.UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.Show();
            this.Hide();
        }

        private void EditExperienceButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string experienceId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the experience ID
            int id = int.Parse(experienceId);
            EditWorkExperienceWindow editWorkExperienceWindow = new EditWorkExperienceWindow(UserId, id);
            editWorkExperienceWindow.ShowDialog();

            // Call a method to edit the experience item using the experienceId
            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.Show();
            this.Close();
        }

        private void DeleteExperienceButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string experienceId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the experience ID
            int id = int.Parse(experienceId);

            // Call a method to delete the experience item using the experienceId
            ExperienceRepo.Delete(id);
            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.ShowDialog();
            this.Hide();

        }

        private void EditCertificationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string certificationId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the certification ID
            int id = int.Parse(certificationId);

            EditCertificateWindow editCertificateWindow = new EditCertificateWindow(UserId, id);
            editCertificateWindow.ShowDialog();

            // Call a method to edit the certification item using the certificationId
            //EditCertification(certificationId);
            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            this.Close();
            profilePage.Show();
        }

        private void DeleteCertificationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string certificationId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the certification ID
            int id = int.Parse(certificationId);

            // Call a method to delete the certification item using the certificationId
            CertificationsRepo.Delete(id);
            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.Show();
            this.Hide();
        }

        private void EditSkillsButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string skillId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the skill ID
            int id = int.Parse(skillId);
            // Call a method to edit the skill item using the skillId

        }

        private void DeleteSkillsButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string skillId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the skill ID
            int id = int.Parse(skillId);

            // Call a method to delete the skill item using the skillId
            SkillsRepo.Delete(id);
            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.Show();
            this.Hide();
        }

        private void EditVolunteeringButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string volunteeringId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the volunteering ID
            int id = int.Parse(volunteeringId);

            EditVolunteeringWindow volunteeringWindow = new EditVolunteeringWindow(UserId, id);
            volunteeringWindow.ShowDialog();
            // Call a method to edit the volunteering item using the volunteeringId
            //EditVolunteering(volunteeringId);

            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.Show();
            this.Close();
        }

        private void DeleteVolunteeringButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string volunteeringId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the volunteering ID
            int id = int.Parse(volunteeringId);

            // Call a method to delete the volunteering item using the volunteeringId
            VolunteeringRepo.Delete(id);
            ProfilePage profilePage = new ProfilePage(CurrentUserId, UserId);
            profilePage.WindowState = WindowState.Maximized;
            profilePage.Show();
            this.Hide();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Get the URL from the Hyperlink
            string url = e.Uri.AbsoluteUri;

            // Open the URL in the default web browser
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });

            // Mark the event as handled
            e.Handled = true;
        }


        // Define properties for profile information
        public int CurrentUserId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Summary { get; set; }
        public List<Education> Education { get; set; }
        public EducationRepo EducationRepo { get; set; }
        public List<WorkExperience> Experience { get; set; }
        public WorkExperienceRepo ExperienceRepo { get; set; }
        public List<Certificate> Certifications { get; set; }
        public CertificateRepo CertificationsRepo { get; set; }
        public List<Skill> Skills { get; set; }
        public SkillRepo SkillsRepo { get; set; }
        public List<Volunteering> Volunteering { get; set; }    
        public VolunteeringRepo VolunteeringRepo { get; set; }


        private void SearchPageButton_Click(object sender, RoutedEventArgs e)
        {
            SearchUserPage searchUserPage = new SearchUserPage(CurrentUserId);

            searchUserPage.Show();
        }

        private void ViewNotificationsButton_Click(object sender, RoutedEventArgs e)
        {
            NotificationsPage notificationsPage = new NotificationsPage(CurrentUserId);
            notificationsPage.Show();
        }

        private void createAssessmentButton_Click(object sender, RoutedEventArgs e)
        {
            CreateAssessmentWindow createAssessmentWindow = new CreateAssessmentWindow(CurrentUserId);
            createAssessmentWindow.Show();
        }

        private void takeAssessmentButton_Click(object sender, RoutedEventArgs e)
        {
            SelectTestWindow selectTestWindow = new SelectTestWindow(CurrentUserId);
            selectTestWindow.Show();
        }

        private void becomePremiumUserButton_Click(object sender, RoutedEventArgs e)
        {
            PremiumUsersService premiumUsersService = new PremiumUsersService();
            premiumUsersService.AddPremiumUser(CurrentUserId);
            this.becomePremiumUserButton.Visibility = Visibility.Hidden;
            this.createAssessmentButton.Visibility = Visibility.Visible;

            MessageBox.Show("You are now a premium user", "Success", MessageBoxButton.OK);
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            PrivacySettingsPage privacySettingsPage = new PrivacySettingsPage(CurrentUserId);
            privacySettingsPage.Show();
        }

        private void viewProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            bool isVisiting = CurrentUserId != UserId;
            ProjectsPage projectsPage = new ProjectsPage(UserId, isVisiting);
            projectsPage.Show();
        }

        private void viewBusinessCardButton_Click(object sender, RoutedEventArgs e)
        {
            BusinessCardPage businessCardPage = new BusinessCardPage(UserId);
            businessCardPage.Show();
        }
    }

}
