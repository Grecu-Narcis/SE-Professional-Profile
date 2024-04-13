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
    public class AddVolunteeringCommand : SectionCommandBase
    {
        private readonly VolunteeringRepo _volunteeringRepo;
        private readonly VolunteeringViewModel _volunteeringViewModel;

        public AddVolunteeringCommand(VolunteeringRepo volunteeringRepo, VolunteeringViewModel volunteeringViewModel)
        {
            _volunteeringRepo = volunteeringRepo;
            _volunteeringViewModel = volunteeringViewModel;

            _volunteeringViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            Volunteering volunteering = new Volunteering(4, 4, _volunteeringViewModel.Organisation, _volunteeringViewModel.Role, _volunteeringViewModel.Description);

            //try catch block
            _volunteeringRepo.Add(volunteering);
            MessageBox.Show("Volunteering added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_volunteeringViewModel.Organisation) &&
                !string.IsNullOrEmpty(_volunteeringViewModel.Role) &&
                !string.IsNullOrEmpty(_volunteeringViewModel.Description) &&
                base.CanExecute(parameter);
        }
        
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(VolunteeringViewModel.Organisation) ||
                               e.PropertyName == nameof(VolunteeringViewModel.Role) ||
                                              e.PropertyName == nameof(VolunteeringViewModel.Description))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
