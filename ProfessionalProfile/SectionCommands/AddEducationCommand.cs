using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
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

        public AddEducationCommand(EducationViewModel educationViewModel, EducationRepo educationRepo)
        {
            _educationRepo = educationRepo;
            _educationViewModel = educationViewModel;

            _educationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            double gpa;
            if (double.TryParse(_educationViewModel.GPA, out gpa))
            {
                Education education = new Education(
                                                4,
                                                4,
                                                _educationViewModel.Degree,
                                                _educationViewModel.Institution,
                                                _educationViewModel.FieldOfStudy,
                                                _educationViewModel.GraduationDate,
                                                gpa
                );

                //add try catch block
                _educationRepo.Add(education);
                MessageBox.Show("Education added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
