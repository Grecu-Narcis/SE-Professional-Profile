using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class WorkExperience
    {
        private int _work_id;
        private string _jobTitle;
        private string _company;
        private string _location;
        private string _employementPeriod;
        private string _responsibilities;
        private string _achievements;
        private string _description;
        private int _user_id;

        public WorkExperience(int work_id, string jobTitle, string company, string location, string employementPeriod, string responsibilities, string achievements, string description, int user_id)
        {
            this._work_id = work_id;
            this._jobTitle = jobTitle;
            this._company = company;
            this._location = location;
            this._employementPeriod = employementPeriod;
            this._responsibilities = responsibilities;
            this._achievements = achievements;
            this._description = description;
            _user_id = user_id;
        }

        public int Work_id
        {
            get { return _work_id; }
            set { _work_id = value; }
        }

        public string JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }

        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string EmployementPeriod
        { 
            get { return _employementPeriod;}
            set { _employementPeriod = value; }
        }

        public string Achievements
        {
            get { return _achievements; }
            set { _achievements = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int User_id
        {
            get { return this._user_id; }
            set { this._user_id = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is WorkExperience experience &&
                   _work_id == experience._work_id &&
                   _jobTitle == experience._jobTitle &&
                   _company == experience._company &&
                   _location == experience._location &&
                   _employementPeriod == experience._employementPeriod &&
                   _responsibilities == experience._responsibilities &&
                   _achievements == experience._achievements &&
                   _description == experience._description &&
                   _user_id == experience._user_id &&
                   User_id  == experience.User_id &&
                   Work_id == experience.Work_id &&
                   JobTitle == experience.JobTitle &&
                   Company == experience.Company &&
                   Location == experience.Location &&
                   EmployementPeriod == experience.EmployementPeriod &&
                   Achievements == experience.Achievements &&
                   Description == experience.Description;
        }
    }
}
