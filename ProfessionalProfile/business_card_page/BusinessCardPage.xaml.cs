using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProfessionalProfile.domain;
using ProfessionalProfile.repo;

namespace ProfessionalProfile.business_card_page
{
    public partial class BusinessCardPage : Window
    {
        UserRepo usersRepo = new UserRepo();
        SkillRepo skillRepo = new SkillRepo();
        BusinessCardRepo businessCardRepo = new BusinessCardRepo();

        public BusinessCardPage(int UserId)
        {
            InitializeComponent();

            this.DownloadCardButton.Visibility = Visibility.Hidden;
            this.DownloadCardButton.Visibility = Visibility.Hidden;

            BussinesCard businessCard = businessCardRepo.GetByUserId(UserId);
            User user = usersRepo.GetById(UserId);
            List<Skill> skills = skillRepo.GetByUserId(UserId);

            if (businessCard == null)

            {
                BussinesCard newCard = new BussinesCard(0, user.Summary, "htpps://business_card_" +  user.FirstName, user.UserId, skills);
                businessCardRepo.Add(newCard);
            }
            businessCard = businessCardRepo.GetByUserId(UserId);

            List<string> cardSkills = new List<string>();

            foreach (Skill skill in skills)
            {
                if (!cardSkills.Contains(skill.Name.ToLower()))
                    cardSkills.Add(skill.Name);
            }

            FullName = user.FirstName + " " + user.LastName;
            PhoneNumber = user.Phone;

            Email = user.Email;
            WebsiteURL = businessCard.UniqueUrl;
            KeySkills = string.Join(",",  cardSkills);
            Description = businessCard.Summary;
            // Achievement = "I have developed 5 applications that are used by millions of people.";

            DataContext = this;
        }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string WebsiteURL { get; set; }
        public string KeySkills { get; set; }
        public string Description { get; set; }
        public string Achievement { get; set; }

        // Commands for button actions
        public ICommand GenerateQRCodeCommand { get; }
        public ICommand GoToProfileCommand { get; }
        public ICommand DownloadCardCommand { get; }

        // Methods for command actions
        private void GenerateQRCode(object parameter)
        {
            // Code to generate QR code
        }

        private void GoToProfile(object parameter)
        {
            // Code to navigate to profile page
        }

        private void DownloadCard(object parameter)
        {
            // Code to download business card
        }

        // Implementation of INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}


