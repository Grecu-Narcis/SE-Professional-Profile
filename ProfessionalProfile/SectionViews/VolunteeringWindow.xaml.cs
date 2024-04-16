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
    /// Interaction logic for VolunteeringWindow.xaml
    /// </summary>
    public partial class VolunteeringWindow : Window
    {
        int userId;
        public VolunteeringWindow(int userId)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            this.userId = userId;
            VolunteeringViewModel viewModel = new VolunteeringViewModel(new VolunteeringRepo(), userId);
            DataContext = viewModel;
        }

        private void OpenSkillWindow(object sender, RoutedEventArgs e)
        {
            SkillWindow skillWindow = new SkillWindow(userId);
            this.Visibility = Visibility.Hidden;
            skillWindow.Show();
        }
    }
}
