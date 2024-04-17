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
    public class CertificateViewModel: SectionViewModelBase
    {
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

        private DateTime _expirationDate = new DateTime(2024, 1, 2);
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set
            {
                _expirationDate = value;
                OnPropertyChanged("ExpirationDate");
            }
        }

        public ICommand AddCertificateButton { get; }

        public CertificateViewModel(CertificateRepo certificateRepo, int userId, bool isLoggedIn)
        {
            AddCertificateButton = new AddCertificateCommand(this, certificateRepo, userId, isLoggedIn);
        }
    }
}
