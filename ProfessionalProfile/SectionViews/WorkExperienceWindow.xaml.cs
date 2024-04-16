using ProfessionalProfile.repo;
using ProfessionalProfile.SectionViewModels;
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

namespace ProfessionalProfile.SectionViews
{
    /// <summary>
    /// Interaction logic for WorkExperienceWindow.xaml
    /// </summary>
    public partial class WorkExperienceWindow : Window
    {
        int userId;
        public WorkExperienceWindow(int userId)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            this.userId = userId;
            WorkExperienceViewModel viewModel = new WorkExperienceViewModel(new WorkExperienceRepo(), userId);
            DataContext = viewModel;
        }

        private void OpenCertificateWindow(object sender, RoutedEventArgs e)
        {
            EducationWindow educationWindow = new EducationWindow(userId);
            this.Visibility = Visibility.Hidden;
            educationWindow.Show();
        }
    }
}
