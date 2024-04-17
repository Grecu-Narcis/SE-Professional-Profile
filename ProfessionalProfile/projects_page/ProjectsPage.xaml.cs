using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProfessionalProfile.repo;

namespace ProfessionalProfile.projects_page
{
    public partial class ProjectsPage : Window
    {

        ProjectRepo projectRepo = new ProjectRepo();
        UserRepo userRepo = new UserRepo();

        public ProjectsPage(int userId, bool isVisiting=false)
        {
            InitializeComponent();

            User user = userRepo.GetById(userId);
            currentUserId = userId;

            if (isVisiting)
                this.nameLabel.Content = user.FirstName + " " + user.LastName + "'s Portfolio";

            else 
                this.nameLabel.Content = "My Portfolio";

            List<Project> projects = projectRepo.GetByUserId(userId);

            ManualProjects = projects;

            //ProjectName = project.ProjectName;
            //ProjectDescription = project.Description;
            //ProjectTechnologies = project.Technologies;

            // Set the data context to this instance
            DataContext = this;    
            
            if (isVisiting)
            {
                AddFromGitHub.Visibility = Visibility.Hidden;
                AddManually.Visibility = Visibility.Hidden;
            }
        }

        int currentUserId;
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
            AddManualProject addManualProject = new AddManualProject(this.currentUserId);
            addManualProject.ShowDialog();

            ProjectsPage projectsPage = new ProjectsPage(this.currentUserId);
            projectsPage.Show();
            Close();
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
