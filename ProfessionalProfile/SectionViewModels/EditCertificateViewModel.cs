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
        private static Certificate certificate;

        private string _certificateName = certificate.Name;
        public string CertificateName
        {
            get { return _certificateName; }
            set
            {
                _certificateName = value;
                OnPropertyChanged("CertificateName");
            }
        }

        private string _issuedBy = certificate.IssuedBy;
        public string IssuedBy
        {
            get { return _issuedBy; }
            set
            {
                _issuedBy = value;
                OnPropertyChanged("IssuedBy");
            }
        }

        private string _description = certificate.Description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private DateTime _issuedDate = certificate.IssuedDate;
        public DateTime IssuedDate
        {
            get { return _issuedDate; }
            set
            {
                _issuedDate = value;
                OnPropertyChanged("IssuedDate");
            }
        }

        private DateTime _expirationDate = certificate.ExpirationDate;
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

        public EditCertificateViewModel(CertificateRepo certificateRepo, int userId, int certificateId) 
        {
            certificate = certificateRepo.GetById(certificateId);
            EditCertificateButton = new EditCertificateCommand(this, certificateRepo, userId, certificateId);
        }
    }
}
