using ProfessionalProfile.domain;
using ProfessionalProfile.profile_page;
using ProfessionalProfile.repo;
using ProfessionalProfile.SectionExceptions;
using ProfessionalProfile.SectionViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProfessionalProfile.SectionCommands
{
    public class AddCertificateCommand : SectionCommandBase
    {
        private readonly CertificateRepo _certificateRepo;
        private readonly CertificateViewModel _certificateViewModel;
        private readonly int _userId;
        private bool isLoggedIn;

        public AddCertificateCommand(SectionViewModels.CertificateViewModel certificateViewModel, CertificateRepo certificateRepo, int userId, bool isLoggedIn)
        {
            _certificateRepo = certificateRepo;
            _certificateViewModel = certificateViewModel;
            _userId = userId;
            this.isLoggedIn = isLoggedIn;
            _certificateViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        

        public override void Execute(object parameter)
        {
            Certificate certificate = new Certificate(
                    4,
                    _userId,
                    _certificateViewModel.CertificateName,
                    _certificateViewModel.IssuedBy,
                    _certificateViewModel.Description,
                    _certificateViewModel.IssuedDate,
                    _certificateViewModel.ExpirationDate
                );

            try
            {
                _certificateRepo.Add(certificate);
                MessageBox.Show("Certificate added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ProfilePage profilePage = new ProfilePage(_userId, _userId);
                profilePage.Show();
            }
            catch (CustomSectionException ex)
            {
               MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_certificateViewModel.CertificateName) &&
                !string.IsNullOrEmpty(_certificateViewModel.IssuedBy) &&
                !string.IsNullOrEmpty(_certificateViewModel.Description) &&
                base.CanExecute(parameter);
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CertificateViewModel.CertificateName) ||
                e.PropertyName == nameof(CertificateViewModel.IssuedBy) ||
                e.PropertyName == nameof(CertificateViewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
