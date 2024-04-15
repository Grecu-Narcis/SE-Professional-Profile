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
    /// Interaction logic for EducationWindow.xaml
    /// </summary>
    public partial class EducationWindow : Window
    {
        int userId;
        public EducationWindow(int userId)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            EducationViewModel viewModel = new EducationViewModel(new EducationRepo());
            DataContext = viewModel;
            this.userId = userId;
        }

        private void OpenWorkExperienceWindow(object sender, RoutedEventArgs e)
        {
            WorkExperienceWindow workExperienceWindow = new WorkExperienceWindow(userId);
            this.Visibility = Visibility.Hidden;
            workExperienceWindow.Show();
        }
    }
}
