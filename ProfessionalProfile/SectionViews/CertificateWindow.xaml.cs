﻿using ProfessionalProfile.repo;
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
    /// Interaction logic for CertificateWindow.xaml
    /// </summary>
    public partial class CertificateWindow : Window
    {
        int userId;
        public CertificateWindow(int userId)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            this.userId = userId;
            CertificateViewModel viewModel = new CertificateViewModel(new CertificateRepo(), userId);
            DataContext = viewModel;
            
        }

        private void OpenVolunteeringWindow(object sender, RoutedEventArgs e)
        {
            VolunteeringWindow volunteeringWindow = new VolunteeringWindow(userId);
            this.Visibility = Visibility.Hidden;
            volunteeringWindow.Show();
        }
    }
}
