using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    class Volunteering
    {
        private int _volunteering_id;
        private string _organisation;
        private string _role;
        private string _description;
        private int _user_id;

        public Volunteering(int volunteering_id, string organisation, string role, string description, int user_id)
        {
            _volunteering_id = volunteering_id;
            _organisation = organisation;
            _role = role;
            _description = description;
            _user_id = user_id;
        }

        public int Volunteering_id { get {  return _volunteering_id; } set { this._volunteering_id = value; } }

        public string Organisation { get { return _organisation; } set { this._organisation = value; } }

        public string Role { get { return _role;} set { this._role = value; } }

        public string Description { get { return _description;} set { this._description = value; } }    

        public int User_id {  get { return _user_id; } set {  _user_id = value; } }

        public override bool Equals(object? obj)
        {
            return obj is Volunteering volunteering &&
                   _volunteering_id == volunteering._volunteering_id &&
                   _organisation == volunteering._organisation &&
                   _role == volunteering._role &&
                   _description == volunteering._description &&
                   _user_id == volunteering._user_id &&
                   Volunteering_id == volunteering.Volunteering_id &&
                   Organisation == volunteering.Organisation &&
                   Role == volunteering.Role &&
                   Description == volunteering.Description &&
                   User_id == volunteering.User_id;
        }
    }
}
