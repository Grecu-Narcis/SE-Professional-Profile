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
    public class EditEducationViewModel: SectionViewModelBase
    {
        public EditEducationViewModel(EducationRepo educationRepo, int userId, int educationId)
        {
            education = educationRepo.GetById(educationId);
            Degree = education.Degree;
            Institution = education.Institution;
            FieldOfStudy = education.FieldOfStudy;
            GraduationDate = education.GraduationDate;
            GPA = education.GPA.ToString();
            EditEducationButton = new EditEducationCommand(this, educationRepo, userId, educationId);
        }

        private Education education;

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

        private string _gpa;
        public string GPA
        {
            get { return _gpa; }
            set
            {
                _gpa = value;
                OnPropertyChanged("GPA");
            }
        }

        public ICommand EditEducationButton { get; }
    }
}
