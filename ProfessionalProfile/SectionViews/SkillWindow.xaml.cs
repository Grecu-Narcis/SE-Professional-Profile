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
    /// Interaction logic for SkillWindow.xaml
    /// </summary>
    public partial class SkillWindow : Window
    {
        int userId;
        public SkillWindow(int userId)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            SkillViewModel viewModel = new SkillViewModel(new SkillRepo());
            DataContext = viewModel;
            this.userId = userId;
        }
    }
}
