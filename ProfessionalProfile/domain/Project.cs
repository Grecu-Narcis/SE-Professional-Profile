using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class Project
    {
        private int _projectId;
        private string _projectName;
        private string _description;
        private string _technologies;
        private string _userId;
        

        public Project(int projectId, string projectName, string description, string technologies, string userId)
        {
            this._projectId = projectId;
            this._projectName = projectName;
            this._description = description;
            this._technologies = technologies;
            this._userId = userId;
        }

        public int ProjectId
        {
            get { return this._projectId; }
            set { this._projectId = value;}
        }

        public string ProjectName
        {
            get { return this._projectName; }
            set { this._projectName = value; }
        }

        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public string Technologies
        {
            get { return this._technologies; }
            set { this._technologies = value; }
        }

        public string UserId{
            get { return this._userId; }
            set { this._userId = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Project project &&
                   _projectId == project._projectId &&
                   _projectName == project._projectName &&
                   _description == project._description &&
                   _technologies == project._technologies &&
                   _userId == project._userId &&
                   ProjectId == project.ProjectId &&
                   ProjectName == project.ProjectName &&
                   Description == project.Description;
        }

        public override string ToString()
        {
            return _projectName + "\n" + _description + "\n" + _technologies;
        }
    }
}
