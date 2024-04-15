using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ProfessionalProfile.profile_page
{

    public partial class ProfilePage : Window
    {
        

        public ProfilePage(string UserId)
        {
            InitializeComponent();

            // Populate sample data we will fetch this from the user object later
            CurrentUserId = "123456"; // this will be fetched from the logged in user
            this.UserId = UserId;
            ProfilePic = "profile.jpg";
            Name = "John Doe";
            Email = "john.doe@example.com";
            Contact = "+1234567890";
            Education = new List<string> { "Bachelor's in Computer Science", "Master's in Software Engineering" };
            Experience = new List<string> { "Software Engineer at ABC Inc.", "Intern at XYZ Corp" };
            Certifications = new List<string> { "Microsoft Certified Professional (MCP)", "AWS Certified Solutions Architect" };
            Skills = new List<string> { "C#", "ASP.NET", "JavaScript", "React", "SQL" };
            Volunteering = new List<string> { "Red Cross Volunteer", "Community Cleanup Organizer" }; // will be of class Volunteering
            MyUrl = "http://website" + UserId;

            // Set the DataContext to this instance
            DataContext = this;
        }

        public Visibility GetButtonVisibility()
        {
            return UserId == CurrentUserId ? Visibility.Visible : Visibility.Collapsed;
        }

        public Visibility GetEndorseButtonVisibility()
        {
            return UserId != CurrentUserId ? Visibility.Visible : Visibility.Collapsed;
        }

        private void AddEducationButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the page for adding education
            //AddEducationPage addEducationPage = new AddEducationPage(); // Replace AddEducationPage with the actual name of your page
            //this.NavigationService.Navigate(addEducationPage);
        }

        private void AddExperienceButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the page for adding experience
            //AddExperiencePage addExperiencePage = new AddExperiencePage(); // Replace AddExperiencePage with the actual name of your page
            //this.NavigationService.Navigate(addExperiencePage);
        }

        private void AddCertificationButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the page for adding certification
            //AddCertificationPage addCertificationPage = new AddCertificationPage(); // Replace AddCertificationPage with the actual name of your page
            //this.NavigationService.Navigate(addCertificationPage);
        }

        private void AddSkillsButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the page for adding skills
            //AddSkillsPage addSkillsPage = new AddSkillsPage(); // Replace AddSkillsPage with the actual name of your page
            //this.NavigationService.Navigate(addSkillsPage);
        }

        private void AddVolunteeringButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the page for adding volunteering
            //AddVolunteeringPage addVolunteeringPage = new AddVolunteeringPage(); // Replace AddVolunteeringPage with the actual name of your page
            //this.NavigationService.Navigate(addVolunteeringPage);
        }

        private void EditEducationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string educationId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the education ID

            // Call a method to edit the education item using the educationId
            //EditEducation(educationId);
        }
        private void DeleteEducationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string educationId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the education ID

            // Call a method to delete the education item using the educationId
            //DeleteEducation(educationId);
        }

        private void EditExperienceButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string experienceId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the experience ID

            // Call a method to edit the experience item using the experienceId
            //EditExperience(experienceId);
        }

        private void DeleteExperienceButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string experienceId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the experience ID

            // Call a method to delete the experience item using the experienceId
            //DeleteExperience(experienceId);
        }

        private void EditCertificationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string certificationId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the certification ID

            // Call a method to edit the certification item using the certificationId
            //EditCertification(certificationId);
        }

        private void DeleteCertificationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string certificationId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the certification ID

            // Call a method to delete the certification item using the certificationId
            //DeleteCertification(certificationId);
        }

        private void EditSkillsButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string skillId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the skill ID

            // Call a method to edit the skill item using the skillId
            //EditSkill(skillId);
        }

        private void DeleteSkillsButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string skillId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the skill ID

            // Call a method to delete the skill item using the skillId
            //DeleteSkill(skillId);
        }

        private void EditVolunteeringButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string volunteeringId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the volunteering ID

            // Call a method to edit the volunteering item using the volunteeringId
            //EditVolunteering(volunteeringId);
        }

        private void DeleteVolunteeringButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string volunteeringId = button.Tag.ToString(); // Assuming you set the Tag property of the button to the volunteering ID

            // Call a method to delete the volunteering item using the volunteeringId
            //DeleteVolunteering(volunteeringId);
        }

        private void LightThemeButton_Click(object sender, RoutedEventArgs e)
        {
            // Call a method to switch to light theme
            //SwitchToLightTheme();
        }

        private void DarkThemeButton_Click(object sender, RoutedEventArgs e)
        {
            // Call a method to switch to dark theme
            //SwitchToDarkTheme();
        }

        // Define properties for profile information
        public string MyUrl { get; set; }
        public string CurrentUserId { get; set; }
        public string UserId { get; set; }
        public string ProfilePic { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public List<string> Education { get; set; }
        public List<string> Experience { get; set; }
        public List<string> Certifications { get; set; }
        public List<string> Skills { get; set; }
        public List<string> Volunteering { get; set; }
    }

}
