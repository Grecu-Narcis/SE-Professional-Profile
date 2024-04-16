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
    public partial class AddManualProject : Window
    {
        ProjectRepo projectRepo = new ProjectRepo();

        int currentUserId;

        public AddManualProject(int userId)
        {
            InitializeComponent();

            currentUserId = userId;

            textName = null;
            textDescription = null;
            textTechnologies = null;

            // Set the data context to this instance
            DataContext = this;
        }
        // Event handler for the "Save" button click
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Get the text entered in the text boxes
            string projectName = textName;
            string projectDescription = textDescription;
            string projectTechnologies = textTechnologies;

            // Validate input fields
            if (string.IsNullOrWhiteSpace(projectName) || string.IsNullOrWhiteSpace(projectDescription) || string.IsNullOrWhiteSpace(projectTechnologies))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Project project = new Project(0, projectName, projectDescription, projectTechnologies, currentUserId.ToString());

            // Save the project or perform further actions here
            projectRepo.Add(project);

            // For now, let's just close the window
            Close();
        }

        // Event handler for the "Cancel" button click
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without saving
            Close();
        }

        public string textName { get; set; }
        public string textDescription { get; set; }
        public string textTechnologies { get; set; }


    }
}
