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
    public class EditEducationCommand : SectionCommandBase
    {
        private readonly EditEducationViewModel _viewModel;
        private readonly EducationRepo _educationRepo;
        private readonly int _userId;
        private readonly int _educationId;

        public EditEducationCommand(EditEducationViewModel viewModel, EducationRepo educationRepo, int userId, int educationId)
        {
            _viewModel = viewModel;
            _educationRepo = educationRepo;
            _userId = userId;
            _educationId = educationId;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            double gpa;
            if (double.TryParse(_viewModel.GPA, out gpa))
            {
                Education updatedEducation = new Education(
                                   _educationId,
                                                  _userId,
                                                                 _viewModel.Degree,
                                                                                _viewModel.Institution,
                                                                                               _viewModel.FieldOfStudy,
                                                                                                              _viewModel.GraduationDate,
                                                                                                                             gpa
                                                                                                                                        );
                try
                {
                    _educationRepo.Update(updatedEducation); ;
                    MessageBox.Show("Education updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (CustomSectionException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
                MessageBox.Show("Invalid GPA value. Please enter a numerical value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Degree) &&
                !string.IsNullOrEmpty(_viewModel.Institution) &&
                !string.IsNullOrEmpty(_viewModel.FieldOfStudy) &&
                !string.IsNullOrEmpty(_viewModel.GPA) &&
                base.CanExecute(parameter);
        }
        
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Degree) ||
                               e.PropertyName == nameof(_viewModel.Institution) ||
                                              e.PropertyName == nameof(_viewModel.FieldOfStudy) ||
                                                             e.PropertyName == nameof(_viewModel.GPA))
                OnCanExecuteChanged();
        }
    }
}
