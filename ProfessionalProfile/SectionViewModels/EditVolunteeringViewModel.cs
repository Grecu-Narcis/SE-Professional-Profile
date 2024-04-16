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
    public class EditVolunteeringViewModel: SectionViewModelBase
    {
        public EditVolunteeringViewModel(VolunteeringRepo volunteeringRepo, int userId, int volunteeringId)
        {
            volunteering = volunteeringRepo.GetById(volunteeringId);
            Organisation = volunteering.Organisation;
            Role = volunteering.Role;
            Description = volunteering.Description;
            EditVolunteeringButton = new EditVolunteeringCommand(this, volunteeringRepo, userId, volunteeringId);
        }
        private Volunteering volunteering;

        private string _organisation;
        public string Organisation
        {
            get { return _organisation; }
            set
            {
                _organisation = value;
                OnPropertyChanged("Organisation");
            }
        }

        private string _role;
        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged("Role");
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

        public ICommand EditVolunteeringButton { get; }
    }
}
