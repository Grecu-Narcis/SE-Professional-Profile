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
    /// Interaction logic for EditWorkExperienceWindow.xaml
    /// </summary>
    public partial class EditWorkExperienceWindow : Window
    {
        public EditWorkExperienceWindow(int userId, int workExperienceId)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            EditWorkExperienceViewModel viewModel = new EditWorkExperienceViewModel(new WorkExperienceRepo(), userId, workExperienceId);
            DataContext = viewModel;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
