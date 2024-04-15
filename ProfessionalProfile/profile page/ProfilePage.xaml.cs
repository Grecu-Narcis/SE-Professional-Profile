using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
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

    public partial class ProfilePage : Window
    {
        
        UserRepo usersRepo = new UserRepo();
        public ProfilePage(int UserId)
        {
            InitializeComponent();

            // Populate sample data we will fetch this from the user object later
            CurrentUserId = 41; // this will be fetched from the logged in user
            this.UserId = UserId;
            User user = usersRepo.GetById(UserId);
            this.Name = user.FirstName + user.LastName;
            Email = user.Email;
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
        public int CurrentUserId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
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
    }

}
