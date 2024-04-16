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
    public class EditVolunteeringCommand : SectionCommandBase
    {
        private readonly EditVolunteeringViewModel _viewModel;
        private readonly VolunteeringRepo _volunteeringRepo;
        private readonly int _userId;
        private readonly int _volunteeringId;

        public EditVolunteeringCommand(EditVolunteeringViewModel viewModel, VolunteeringRepo volunteeringRepo, int userId, int volunteeringId)
        {
            _viewModel = viewModel;
            _volunteeringRepo = volunteeringRepo;
            _userId = userId;
            _volunteeringId = volunteeringId;

            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Organisation) ||
                               e.PropertyName == nameof(_viewModel.Role) ||
                                             e.PropertyName == nameof(_viewModel.Description))
                OnCanExecuteChanged();
        }

        public override void Execute(object parameter)
        {
            Volunteering updatedVolunteering = new Volunteering(
                                               _volunteeringId,
                                              _userId,
                                              _viewModel.Organisation, _viewModel.Role, _viewModel.Description);

            try
            {
                _volunteeringRepo.Update(updatedVolunteering);
                MessageBox.Show("Volunteering updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (CustomSectionException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Organisation) &&
                !string.IsNullOrEmpty(_viewModel.Role) &&
                !string.IsNullOrEmpty(_viewModel.Description);
        }
    }
}
