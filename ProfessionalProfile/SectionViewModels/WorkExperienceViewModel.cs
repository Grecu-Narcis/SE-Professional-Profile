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
    public class WorkExperienceViewModel: SectionViewModelBase
    {
        private string _jobTitle;
        public string JobTitle
        {
            get { return _jobTitle; }
            set
            {
                _jobTitle = value;
                OnPropertyChanged("JobTitle");
            }
        }

        private string _company;
        public string Company
        {
            get { return _company; }
            set
            {
                _company = value;
                OnPropertyChanged("Company");
            }
        }

        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        private string _employmentPeriod;
        public string EmploymentPeriod
        {
            get { return _employmentPeriod; }
            set
            {
                _employmentPeriod = value;
                OnPropertyChanged("EmploymentPeriod");
            }
        }

        private string _responsibilities;
        public string Responsibilities
        {
            get { return _responsibilities; }
            set
            {
                _responsibilities = value;
                OnPropertyChanged("Responsibilities");
            }
        }

        private string _achievements;
        public string Achievements
        {
            get { return _achievements; }
            set
            {
                _achievements = value;
                OnPropertyChanged("Achievements");
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

        public ICommand AddWorkExperienceButton { get; }

        public WorkExperienceViewModel(WorkExperienceRepo workExperienceRepo, int userId)
        {
            AddWorkExperienceButton = new AddWorkExperienceCommand(this, workExperienceRepo, userId);
        }
    }
}
