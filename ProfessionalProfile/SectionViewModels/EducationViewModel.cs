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
    public class EducationViewModel: SectionViewModelBase
    {
        private string _degree;
        public string Degree
        {
            get { return _degree; }
            set
            {
                _degree = value;
                OnPropertyChanged("Degree");
            }
        }

        private string _institution;
        public string Institution
        {
            get { return _institution; }
            set
            {
                _institution = value;
                OnPropertyChanged("Institution");
            }
        }

        private string _fieldOfStudy;
        public string FieldOfStudy
        {
            get { return _fieldOfStudy; }
            set
            {
                _fieldOfStudy = value;
                OnPropertyChanged("FieldOfStudy");
            }
        }

        private DateTime _graduationDate = new DateTime(2024, 1, 1);
        public DateTime GraduationDate
        {
            get { return _graduationDate; }
            set
            {
                _graduationDate = value;
                OnPropertyChanged("GraduationDate");
            }
        }

        private string _GPA;
        public string GPA
        {
            get { return _GPA; }
            set
            {
                _GPA = value;
                OnPropertyChanged("GPA");
            }
        }

        public ICommand AddEducationButton { get; }

        public EducationViewModel(EducationRepo educationRepo, int userId)
        {
            AddEducationButton = new AddEducationCommand(this, educationRepo, userId);
        }
    }
}
