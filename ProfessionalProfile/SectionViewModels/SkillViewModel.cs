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
    public class SkillViewModel: SectionViewModelBase
    {
        private string _skillName;
        public string SkillName
        {
            get { return _skillName; }
            set
            {
                _skillName = value;
                OnPropertyChanged("SkillName");
            }
        }

        public ICommand AddSkillButton { get; }

        public SkillViewModel(SkillRepo skillRepo, int userId)
        {
            AddSkillButton = new AddSkillCommand(this, skillRepo, userId);
        }
    }
}
