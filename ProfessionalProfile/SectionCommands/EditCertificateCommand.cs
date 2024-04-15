using ProfessionalProfile.domain;
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
    class EditCertificateCommand : SectionCommandBase
    {
        private readonly CertificateRepo _certificateRepo;
        private readonly EditCertificateViewModel _certificateViewModel;
        private readonly int _certificateId;
        private readonly int _userId;

        public EditCertificateCommand(EditCertificateViewModel certificateViewModel, CertificateRepo certificateRepo, int userId, int certificateId)
        {
            _certificateRepo = certificateRepo;
            _certificateViewModel = certificateViewModel;
            _certificateId = certificateId;
            _userId = userId;
            _certificateViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            Certificate updatedCertificate = new Certificate(
                               _certificateId,
                                              _userId,
                                                             _certificateViewModel.CertificateName,
                                                                            _certificateViewModel.IssuedBy,
                                                                                           _certificateViewModel.Description,
                                                                                                          _certificateViewModel.IssuedDate,
                                                                                                                         _certificateViewModel.ExpirationDate
                                                                                                                                    );

            try
            {
                _certificateRepo.Update(updatedCertificate);
                MessageBox.Show("Certificate updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (CustomSectionException ex)
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
