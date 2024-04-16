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
    public class AddEducationCommand: SectionCommandBase
    {
        private readonly EducationRepo _educationRepo;
        private readonly EducationViewModel _educationViewModel;
        private readonly int _userId;

        public AddEducationCommand(EducationViewModel educationViewModel, EducationRepo educationRepo, int userId)
        {
            _educationRepo = educationRepo;
            _educationViewModel = educationViewModel;
            _userId = userId;
            _educationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            double gpa;
            if (double.TryParse(_educationViewModel.GPA, out gpa))
            {
                Education education = new Education(
                                                4,
                                                _userId,
                                                _educationViewModel.Degree,
                                                _educationViewModel.Institution,
                                                _educationViewModel.FieldOfStudy,
                                                _educationViewModel.GraduationDate,
                                                gpa
                );

                try
                {
                    _educationRepo.Add(education);
                    MessageBox.Show("Education added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
            return !string.IsNullOrEmpty(_educationViewModel.Degree) &&
                !string.IsNullOrEmpty(_educationViewModel.Institution) &&
                !string.IsNullOrEmpty(_educationViewModel.FieldOfStudy) &&
                !string.IsNullOrEmpty(_educationViewModel.GPA) &&
                base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(EducationViewModel.Degree) ||
                               e.PropertyName == nameof(EducationViewModel.Institution) ||
                                              e.PropertyName == nameof(EducationViewModel.FieldOfStudy) ||
                                                             e.PropertyName == nameof(EducationViewModel.GPA))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
