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

namespace ProfessionalProfile.profile_page
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Window
    {
        public ProfilePage()
        {
            InitializeComponent();

            // Populate sample data we will fetch this from the user object later
            ProfilePic = "profile.jpg";
            Name = "John Doe";
            Email = "john.doe@example.com";
            Contact = "+1234567890";
            Education = new List<string> { "Bachelor's in Computer Science", "Master's in Software Engineering" };
            Experience = new List<string> { "Software Engineer at ABC Inc.", "Intern at XYZ Corp" };
            Certifications = new List<string> { "Microsoft Certified Professional (MCP)", "AWS Certified Solutions Architect" };
            Skills = new List<string> { "C#", "ASP.NET", "JavaScript", "React", "SQL" };
            Volunteering = new List<string> { "Red Cross Volunteer", "Community Cleanup Organizer" }; // will be of class Volunteering

            // Set the DataContext to this instance
            DataContext = this;
        }

        // Define properties for profile information
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
