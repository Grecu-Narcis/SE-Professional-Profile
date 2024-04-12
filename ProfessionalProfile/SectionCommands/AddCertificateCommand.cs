using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
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

        public AddCertificateCommand(SectionViewModels.CertificateViewModel certificateViewModel, CertificateRepo certificateRepo)
        {
            _certificateRepo = certificateRepo;
            _certificateViewModel = certificateViewModel;

            _certificateViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        

        public override void Execute(object parameter)
        {
            //user id 4 always
            Certificate certificate = new Certificate(
                    4,
                    4,
                    _certificateViewModel.CertificateName,
                    _certificateViewModel.IssuedBy,
                    _certificateViewModel.Description,
                    _certificateViewModel.IssuedDate,
                    _certificateViewModel.ExpirationDate
                );

            //add try catch block
            _certificateRepo.Add(certificate);
            MessageBox.Show("Certificate added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
