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
    /// Interaction logic for PrivacySettingsPage.xaml
    /// </summary>
    public partial class PrivacySettingsPage : Window
    {
        public int userId;

        private SearchUsersService SearchUsersService { get; set; }
        private PrivacyService PrivacyService { get; set; }

        public PrivacySettingsPage(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            SearchUsersService = new SearchUsersService(new UserRepo());
            PrivacyService = new PrivacyService();

            loadPrivacy();
        }

        public void loadPrivacy()
        {
            User currentUser = SearchUsersService.getUserById(userId);
            Privacy privacy = PrivacyService.GetPrivacy(currentUser.UserId);

            this.helloLabel.Content = "Hello " + currentUser.FirstName + " " + currentUser.LastName;

            if (privacy.canViewEducation)
                educationPublicCheckBox.IsChecked = true;
            else
                educationPrivateCheckBox.IsChecked = true;

            if (privacy.canViewWorkExperience)
                workExperiencePublicCheckBox.IsChecked = true;
            else
                workExperiencePrivateCheckBox.IsChecked = true;

            if (privacy.canViewSkills)
                skillsPublicCheckBox.IsChecked = true;
            else
                skillsPrivateCheckBox.IsChecked = true;

            if (privacy.canViewCertificates)
                certificationsPublicCheckBox.IsChecked = true;
            else
                certificationsPrivateCheckBox.IsChecked = true;

            if (privacy.canViewVolunteering)
                volunteeringPublicCheckBox.IsChecked = true;
            else
                volunteeringPrivateCheckBox.IsChecked = true;

            if (privacy.canViewProjects)
                projectsPublicCheckBox.IsChecked = true;
            else
                projectsPrivateCheckBox.IsChecked = true;
        }

        private void educationPublicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            educationPrivateCheckBox.IsChecked = false;
        }

        private void educationPrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            educationPublicCheckBox.IsChecked = false;
        }

        private void workExperiencePublicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            workExperiencePrivateCheckBox.IsChecked = false;
        }

        private void workExperiencePrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            workExperiencePublicCheckBox.IsChecked = false;
        }

        private void volunteeringPublicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            volunteeringPrivateCheckBox.IsChecked = false;
        }

        private void volunteeringPrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            volunteeringPublicCheckBox.IsChecked = false;
        }

        private void certificationsPublicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            certificationsPrivateCheckBox.IsChecked = false;
        }

        private void certificationsPrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            certificationsPublicCheckBox.IsChecked = false;
        }

        private void skillsPublicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            skillsPrivateCheckBox.IsChecked = false;
        }

        private void skillsPrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            skillsPublicCheckBox.IsChecked = false;
        }

        private void projectsPublicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            projectsPrivateCheckBox.IsChecked = false;
        }

        private void projectsPrivateCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            projectsPublicCheckBox.IsChecked = false;
        }

        private void changePrivacyButton_Click(object sender, RoutedEventArgs e)
        {
            bool canViewEducation = isPublic(educationPublicCheckBox, educationPrivateCheckBox);
            bool canViewWorkExperience = isPublic(workExperiencePublicCheckBox, workExperiencePrivateCheckBox);
            bool canViewSkills = isPublic(skillsPublicCheckBox, skillsPrivateCheckBox);
            bool canViewCertificates = isPublic(certificationsPublicCheckBox, certificationsPrivateCheckBox);
            bool canViewVolunteering = isPublic(volunteeringPublicCheckBox, volunteeringPrivateCheckBox);
            bool canViewProjects = isPublic(projectsPublicCheckBox, projectsPrivateCheckBox);

            Privacy privacy = new Privacy(userId, canViewEducation, canViewWorkExperience, canViewSkills, canViewCertificates, canViewVolunteering, canViewProjects);
            PrivacyService.UpdatePrivacy(privacy);

            this.updateSuccessLabel.Content = "Privacy settings updated successfully!";
        }

        private bool isPublic(CheckBox publicCheckBox, CheckBox privateCheckBox)
        {
            return publicCheckBox.IsChecked == true && privateCheckBox.IsChecked == false;
        }
    }
}
