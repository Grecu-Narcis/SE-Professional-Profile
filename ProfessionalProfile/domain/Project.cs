using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class Project
    {
        private int _project_id;
        private string _projectName;
        private string _description;
        private List<string> _tehnologies;
        

        public Project(int id, string name, string desc, List<string> tech)
        {
            this._project_id = id;
            this._projectName = name;
            this._description = desc;
            this._tehnologies = tech;
        }

        public int Proj_id
        {
            get { return this._project_id; }
            set { this._project_id = value;}
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

        public List<string> Tehnologies
        {
            get { return this._tehnologies; }
            set { this._tehnologies = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Project project &&
                   _project_id == project._project_id &&
                   _projectName == project._projectName &&
                   _description == project._description &&
                   EqualityComparer<List<string>>.Default.Equals(_tehnologies, project._tehnologies) &&
                   Proj_id == project.Proj_id &&
                   ProjectName == project.ProjectName &&
                   Description == project.Description &&
                   EqualityComparer<List<string>>.Default.Equals(Tehnologies, project.Tehnologies);
        }
    }
}
