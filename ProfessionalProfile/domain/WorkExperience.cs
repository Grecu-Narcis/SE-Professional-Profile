using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class WorkExperience
    {
        private int _workId;
        private int _userId;
        private string _jobTitle;
        private string _company;
        private string _location;
        private string _employmentPeriod;
        private string _responsibilities;
        private string _achievements;
        private string _description;
        

        public WorkExperience(int workId, int userId, string jobTitle, string company, string location, string employmentPeriod, string responsibilities, string achievements, string description)
        {
            this._workId = workId;
            this._jobTitle = jobTitle;
            this._company = company;
            this._location = location;
            this._employmentPeriod = employmentPeriod;
            this._responsibilities = responsibilities;
            this._achievements = achievements;
            this._description = description;
            this._userId = userId;
        }

        public int WorkId
        {
            get { return _workId; }
            set { _workId = value; }
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

        public string EmploymentPeriod
        { 
            get { return _employmentPeriod;}
            set { _employmentPeriod = value; }
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

        public int UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public string Responsibilities
        {
            get { return _responsibilities; }
            set { _responsibilities = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is WorkExperience experience &&
                   _workId == experience._workId &&
                   _jobTitle == experience._jobTitle &&
                   _company == experience._company &&
                   _location == experience._location &&
                   _employmentPeriod == experience._employmentPeriod &&
                   _responsibilities == experience._responsibilities &&
                   _achievements == experience._achievements &&
                   _description == experience._description &&
                   _userId == experience._userId &&
                   UserId  == experience.UserId &&
                   WorkId == experience.WorkId &&
                   JobTitle == experience.JobTitle &&
                   Company == experience.Company &&
                   Location == experience.Location &&
                   EmploymentPeriod == experience.EmploymentPeriod &&
                   Achievements == experience.Achievements &&
                   Description == experience.Description;
        }

        public override string ToString()
        {
            return _jobTitle + "\n" + _company + "\n" + _location + "\n" + _employmentPeriod + "\n" +
                _responsibilities + "\n" + _description + "\n" + _achievements;
        }
    }
}
