using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    class Education
    {
        private int _education_id;
        private string _degree;
        private string _institution;
        private string _fieldOfStudy;
        private DateTime _graduationDate;
        private double _gpa;
        private int _user_id;

        public Education(int ed_id, string degree, string institution, string fieldOfStudy, DateTime graduationDate, double gpa, int user_id)
        {
            this._education_id = ed_id;
            this._degree = degree;
            this._institution = institution;
            this._fieldOfStudy = fieldOfStudy;
            this._graduationDate = graduationDate;
            this._gpa = gpa;
            this._user_id = user_id;
        }

        public int Education_id
        {
            get { return _education_id; }
            set { _education_id = value; }
        }

        public string Degree
        {
            get { return _degree; }
            set { _degree = value; }
        }
        public string Institution
        { get { return _institution; } set
            {
                _institution = value;
            } }

        public string FieldOfStudy
        {
            get { return _fieldOfStudy; }
            set { _fieldOfStudy = value; }
        }

        public DateTime GraduationDate
        {
            get { return _graduationDate; }
            set { _graduationDate = value; }
        }

        public double Gpa
        {
            get { return this._gpa; }
            set { this._gpa = value; }
        }

        public int User_id { get { return this._user_id} set {  this._user_id = value; } }

        public override bool Equals(object? obj)
        {
            return obj is Education education &&
                   _education_id == education._education_id &&
                   _degree == education._degree &&
                   _institution == education._institution &&
                   _fieldOfStudy == education._fieldOfStudy &&
                   _graduationDate == education._graduationDate &&
                   _gpa == education._gpa &&
                   _user_id == education._user_id &&
                   User_id == education.User_id &&
                   Education_id == education.Education_id &&
                   Degree == education.Degree &&
                   Institution == education.Institution &&
                   FieldOfStudy == education.FieldOfStudy &&
                   GraduationDate == education.GraduationDate &&
                   Gpa == education.Gpa;
        }
    }
}
