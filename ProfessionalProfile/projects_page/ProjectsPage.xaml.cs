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


        public ProjectsPage()
        {
            InitializeComponent();

            Project project = projectRepo.GetById(1);
            List<Project> projects = projectRepo.GetAll();

            ManualProjects = projects;

            //ProjectName = project.ProjectName;
            //ProjectDescription = project.Description;
            //ProjectTechnologies = project.Technologies;

            // Set the data context to this instance
            DataContext = this;
            
        }

        string ProjectName { get; set; }
        string ProjectDescription { get; set; }
        string ProjectTechnologies { get; set; }


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
