using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class Volunteering
    {
        private int _volunteeringId; 
        private int _userId;
        private string _organisation;
        private string _role;
        private string _description;
        

        public Volunteering(int volunteeringId, int userId, string organisation, string role, string description)
        {
            _volunteeringId = volunteeringId;
            _organisation = organisation;
            _role = role;
            _description = description;
            _userId = userId;
        }

        public int VolunteeringId { get {  return _volunteeringId; } set { this._volunteeringId = value; } }

        public string Organisation { get { return _organisation; } set { this._organisation = value; } }

        public string Role { get { return _role;} set { this._role = value; } }

        public string Description { get { return _description;} set { this._description = value; } }    

        public int UserId {  get { return _userId; } set {  _userId = value; } }

        public override bool Equals(object? obj)
        {
            return obj is Volunteering volunteering &&
                   _volunteeringId == volunteering._volunteeringId &&
                   _organisation == volunteering._organisation &&
                   _role == volunteering._role &&
                   _description == volunteering._description &&
                   _userId == volunteering._userId &&
                   VolunteeringId == volunteering.VolunteeringId &&
                   Organisation == volunteering.Organisation &&
                   Role == volunteering.Role &&
                   Description == volunteering.Description &&
                   UserId == volunteering.UserId;
        }

        public override string ToString()
        {
            return _role + "\n" + _organisation + "\n" + _description;
        }
    }
}
