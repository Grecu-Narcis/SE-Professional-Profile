using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ProfessionalProfile.domain;

namespace ProfessionalProfile.business_card_page
{
    public partial class BusinessCardPage : Window
    {

        public BusinessCardPage(BussinesCard businessCard)
        {
            InitializeComponent();
            
            Name = "John Doe";
            PhoneNumber = "123-456-7890";
            JobTitle = "Software Developer";
            Company = "Microsoft";
            Email = "johndoe@email.com";
            WebsiteURL = "https://";
            KeySkills = new List<string> { "C#", "Java", "Python", "JavaScript", "SQL" };
            Description = "I am a software developer with 5 years of experience.";
            Achievement = "I have developed 5 applications that are used by millions of people.";

            DataContext = this;
        }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string WebsiteURL { get; set; }
        public List<string> KeySkills { get; set; }
        public string Description { get; set; }
        public string Achievement { get; set; }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }


}
