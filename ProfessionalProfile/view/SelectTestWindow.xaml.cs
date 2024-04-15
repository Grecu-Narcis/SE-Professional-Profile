using ProfessionalProfile.business;
using ProfessionalProfile.domain;
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
    /// Interaction logic for SelectTestWindow.xaml
    /// </summary>
    public partial class SelectTestWindow : Window
    {
        private SelectTestService selectTestService { get; }

        public SelectTestWindow()
        {
            InitializeComponent();

            selectTestService = new SelectTestService();
            populateTestsNames();
        }

        private void populateTestsNames()
        {
            List<AssessmentTest> tests = selectTestService.getAllAssessmentTests();

            foreach (AssessmentTest test in tests)
            {
                assessmentNames.Items.Add(test.TestName);
            }
        }

        private void assessmentNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = (string)assessmentNames.SelectedItem;

            if (selectedItem == null)
            {
                return;
            }

            AssessmentTest test = selectTestService.getAssessmentByName(selectedItem);
            Skill skill = selectTestService.getSkillById(test.Skill_id);

            this.assessmentDescriptionBox.Text = test.Description;
            this.skillTestedLabel.Content = "Skill tested: " + skill.Name;
        }

        private void SelectTestButton_Click(object sender, RoutedEventArgs e)
        {
            if (assessmentNames.SelectedItem == null)
            {
                MessageBox.Show("Please select a test");
                return;
            }

            string testName = (string)assessmentNames.SelectedItem;

            AssessmentTest test = selectTestService.getAssessmentByName(testName);

            // TODO: Open the test window
            TakeTestWindow takeTestWindow = new TakeTestWindow(test.AssessmentTestId);
            takeTestWindow.Show();
            this.Close();
        }
    }
}
