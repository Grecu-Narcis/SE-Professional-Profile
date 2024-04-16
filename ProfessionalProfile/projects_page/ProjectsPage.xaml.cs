using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProfessionalProfile.domain;
using ProfessionalProfile.repo;

namespace ProfessionalProfile.projects_page
{
    public partial class ProjectsPage : Window
    {

        ProjectRepo projectRepo = new ProjectRepo();
        Project project = new Project(1, "Project 1", "Description 1", "Technologies 1", "User 1");


        public ProjectsPage()
        {
            InitializeComponent();

            // Set the data context to this instance
            DataContext = this;

            // For now, let's just bind the mocked data directly
            List<Project> allProjects = projectRepo.GetAll();
        }

        // Properties to bind to UI elements
        public List<Project> GitHubProjects { get; set; }
        public List<Project> ManualProjects { get; set; }

        // Event handler for the "Add from GitHub" button click
        private void AddFromGitHub_Click(object sender, RoutedEventArgs e)
        {
            // You can implement the logic to add projects from GitHub here
            // For now, let's just display a message box
            MessageBox.Show("Functionality to add projects from GitHub is not yet implemented.");
        }

        // Event handler for the "Add Manually" button click
        private void AddManually_Click(object sender, RoutedEventArgs e)
        {
            // You can implement the logic to add projects manually here
            // For now, let's just display a message box
            MessageBox.Show("Functionality to add projects manually is not yet implemented.");
        }

        // Event handler for the "Go to Profile" button click
        private void GoToProfile_Click(object sender, RoutedEventArgs e)
        {
            // You can implement the logic to navigate to the profile page here
            // For now, let's just close the projects page
            Close();
        }
    }
}
