using ProfessionalProfile.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.SectionViewModels
{
    internal class SectionMainViewModel: SectionViewModelBase
    {
        public SectionViewModelBase CurrentViewModel { get; }

        public SectionMainViewModel(EducationRepo educationRepo)
        {
            CurrentViewModel = new EducationViewModel(educationRepo);
        }
    }
}
