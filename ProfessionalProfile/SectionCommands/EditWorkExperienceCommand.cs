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
    public class EditWorkExperienceCommand: SectionCommandBase
    {
        private readonly EditWorkExperienceViewModel _viewModel;
        private readonly WorkExperienceRepo _workExperienceRepo;
        private readonly int _userId;
        private readonly int _workExperienceId;

        public EditWorkExperienceCommand(EditWorkExperienceViewModel viewModel, WorkExperienceRepo workExperienceRepo, int userId, int workExperienceId)
        {
            _viewModel = viewModel;
            _workExperienceRepo = workExperienceRepo;
            _userId = userId;
            _workExperienceId = workExperienceId;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.JobTitle) ||
                               e.PropertyName == nameof(_viewModel.Company) ||
                                              e.PropertyName == nameof(_viewModel.Location) ||
                                                             e.PropertyName == nameof(_viewModel.EmploymentPeriod) ||
                                                                            e.PropertyName == nameof(_viewModel.Responsibilities) ||
                                                                                           e.PropertyName == nameof(_viewModel.Achievements) ||
                                                                                                          e.PropertyName == nameof(_viewModel.Description))
                OnCanExecuteChanged();
        }

        public override void Execute(object parameter)
        {
            WorkExperience updatedWorkExperience = new WorkExperience(
                               _workExperienceId,
                                              _userId,
                                                             _viewModel.JobTitle,
                                                                            _viewModel.Company,
                                                                                           _viewModel.Location,
                                                                                                          _viewModel.EmploymentPeriod,
                                                                                                                         _viewModel.Responsibilities,
                                                                                                                                        _viewModel.Achievements,
                                                                                                                                                       _viewModel.Description
                                                                                                                                                                  );

            try
            {
                _workExperienceRepo.Update(updatedWorkExperience);
                MessageBox.Show("Work Experience updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (CustomSectionException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.JobTitle) &&
                !string.IsNullOrEmpty(_viewModel.Company) &&
                !string.IsNullOrEmpty(_viewModel.Location) &&
                !string.IsNullOrEmpty(_viewModel.EmploymentPeriod) &&
                !string.IsNullOrEmpty(_viewModel.Responsibilities) &&
                !string.IsNullOrEmpty(_viewModel.Achievements) &&
                !string.IsNullOrEmpty(_viewModel.Description) &&
                base.CanExecute(parameter);
        }
    }
}
