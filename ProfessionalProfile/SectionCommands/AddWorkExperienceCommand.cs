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
    public class AddWorkExperienceCommand : SectionCommandBase
    {
        private readonly WorkExperienceRepo _workExperienceRepo;
        private readonly WorkExperienceViewModel _workExperienceViewModel;
        private readonly int _userId;

        public AddWorkExperienceCommand(WorkExperienceViewModel workExperienceViewModel, WorkExperienceRepo workExperienceRepo, int userId)
        {
            _workExperienceRepo = workExperienceRepo;
            _workExperienceViewModel = workExperienceViewModel;
            _userId = userId;
            _workExperienceViewModel.PropertyChanged += OnViewModelPropertyChanged;
            
        }

        public override void Execute(object parameter)
        {
            WorkExperience workExperience = new WorkExperience(4, _userId, _workExperienceViewModel.JobTitle, _workExperienceViewModel.Company, _workExperienceViewModel.Location, _workExperienceViewModel.EmploymentPeriod, _workExperienceViewModel.Responsibilities, _workExperienceViewModel.Achievements, _workExperienceViewModel.Description);

            try
            {
                _workExperienceRepo.Add(workExperience);
                MessageBox.Show("Work Experience added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (CustomSectionException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_workExperienceViewModel.JobTitle) &&
                !string.IsNullOrEmpty(_workExperienceViewModel.Company) &&
                !string.IsNullOrEmpty(_workExperienceViewModel.Location) &&
                !string.IsNullOrEmpty(_workExperienceViewModel.EmploymentPeriod) &&
                !string.IsNullOrEmpty(_workExperienceViewModel.Responsibilities) &&
                !string.IsNullOrEmpty(_workExperienceViewModel.Achievements) &&
                !string.IsNullOrEmpty(_workExperienceViewModel.Description) &&
                base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(WorkExperienceViewModel.JobTitle) ||
                               e.PropertyName == nameof(WorkExperienceViewModel.Company) ||
                                              e.PropertyName == nameof(WorkExperienceViewModel.Location) ||
                                                             e.PropertyName == nameof(WorkExperienceViewModel.EmploymentPeriod) ||
                                                                            e.PropertyName == nameof(WorkExperienceViewModel.Responsibilities) ||
                                                                                           e.PropertyName == nameof(WorkExperienceViewModel.Achievements) ||
                                                                                                          e.PropertyName == nameof(WorkExperienceViewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
