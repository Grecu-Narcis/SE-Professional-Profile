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
    public class EditWorkExperienceViewModel: SectionViewModelBase
    {
        public EditWorkExperienceViewModel(WorkExperienceRepo workExperienceRepo, int userId, int workExperienceId)
        {
            workExperience = workExperienceRepo.GetById(workExperienceId);
            JobTitle = workExperience.JobTitle;
            Company = workExperience.Company;
            Location = workExperience.Location;
            EmploymentPeriod = workExperience.EmploymentPeriod;
            Responsibilities = workExperience.Responsibilities;
            Achievements = workExperience.Achievements;
            Description = workExperience.Description;
            EditWorkExperienceButton = new EditWorkExperienceCommand(this, workExperienceRepo, userId, workExperienceId);
        }

        private WorkExperience workExperience;

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

        public ICommand EditWorkExperienceButton { get; }
    }
}
