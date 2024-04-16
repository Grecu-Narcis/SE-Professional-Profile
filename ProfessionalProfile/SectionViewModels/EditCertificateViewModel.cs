using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
using ProfessionalProfile.SectionCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProfessionalProfile.SectionViewModels
{
    class EditCertificateViewModel: SectionViewModelBase
    {
        public EditCertificateViewModel(CertificateRepo certificateRepo, int userId, int certificateId)
        {
            certificate = certificateRepo.GetById(certificateId);
            CertificateName = certificate.Name;
            IssuedBy = certificate.IssuedBy;
            Description = certificate.Description;
            IssuedDate = certificate.IssuedDate;
            ExpirationDate = certificate.ExpirationDate;
            EditCertificateButton = new EditCertificateCommand(this, certificateRepo, userId, certificateId);
        }

        private Certificate certificate;

        private string _certificateName;
        public string CertificateName
        {
            get { return _certificateName; }
            set
            {
                _certificateName = value;
                OnPropertyChanged("CertificateName");
            }
        }

        private string _issuedBy;
        public string IssuedBy
        {
            get { return _issuedBy; }
            set
            {
                _issuedBy = value;
                OnPropertyChanged("IssuedBy");
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private DateTime _issuedDate = new DateTime(2024, 1, 1);
        public DateTime IssuedDate
        {
            get { return _issuedDate; }
            set
            {
                _issuedDate = value;
                OnPropertyChanged("IssuedDate");
            }
        }

        private DateTime _expirationDate = new DateTime(2024, 1, 20);
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set
            {
                _expirationDate = value;
                OnPropertyChanged("ExpirationDate");
            }
        }

        public ICommand EditCertificateButton { get; }

        
    }
}
