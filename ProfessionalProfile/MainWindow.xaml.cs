using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
using ProfessionalProfile.view;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProfessionalProfile
{
    /// <_summary>
    /// Interaction logic for MainWindow.xaml
    /// </_summary>
    public partial class MainWindow : Window
    {
        UserRepo repo;
        public MainWindow()
        {
            InitializeComponent();
            //CreateAssessmentWindow window = new CreateAssessmentWindow();
            //window.Show();

            //SelectTestWindow window1 = new SelectTestWindow();
            //window1.Show();

            SearchUserPage searchUserPage = new SearchUserPage();
            searchUserPage.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}