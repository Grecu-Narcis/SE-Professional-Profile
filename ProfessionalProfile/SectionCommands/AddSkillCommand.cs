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
    public class AddSkillCommand : SectionCommandBase
    {
        private readonly SkillViewModel _skillViewModel;
        private readonly SkillRepo _skillRepo;
        private readonly int _userId;

        public AddSkillCommand(SkillViewModel skillViewModel, SkillRepo skillRepo, int userId)
        {
            _skillViewModel = skillViewModel;
            _skillRepo = skillRepo;
            _userId = userId;
            _skillViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        

        public override void Execute(object parameter)
        {
            string modifiedSkillName = _skillViewModel.SkillName.ToLower().Replace(" ", "");
            Skill skill = new Skill(4, modifiedSkillName);

            //add try catch block
            _skillRepo.Add(skill);
            MessageBox.Show("Skill added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_skillViewModel.SkillName) &&
                base.CanExecute(parameter);
        }
        
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SkillViewModel.SkillName))
                OnCanExecuteChanged();
        }
    }
}
