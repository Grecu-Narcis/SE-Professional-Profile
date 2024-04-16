using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class Education
    {
        private int _educationId;
        private int _userId;
        private string _degree;
        private string _institution;
        private string _fieldOfStudy;
        private DateTime _graduationDate;
        private double _GPA;
        

        public Education(int educationId, int userId, string degree, string institution, string fieldOfStudy, DateTime graduationDate, double GPA )
        {
            this._educationId = educationId;
            this._degree = degree;
            this._institution = institution;
            this._fieldOfStudy = fieldOfStudy;
            this._graduationDate = graduationDate;
            this._GPA = GPA;
            this._userId = userId;
        }

        public int EducationId
        {
            get { return _educationId; }
            set { _educationId = value; }
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

        public double GPA
        {
            get { return this._GPA; }
            set { this._GPA = value; }
        }

        public int UserId { get { return this._userId; } set {  this._userId = value; } }

        public override bool Equals(object? obj)
        {
            return obj is Education education &&
                   _educationId == education._educationId &&
                   _degree == education._degree &&
                   _institution == education._institution &&
                   _fieldOfStudy == education._fieldOfStudy &&
                   _graduationDate == education._graduationDate &&
                   _GPA == education._GPA &&
                   _userId == education._userId &&
                   UserId == education.UserId &&
                   EducationId == education.EducationId &&
                   Degree == education.Degree &&
                   Institution == education.Institution &&
                   FieldOfStudy == education.FieldOfStudy &&
                   GraduationDate == education.GraduationDate &&
                   GPA == education.GPA;
        }

        public override string ToString()
        {
            return _institution + "\n" + _degree +"\n"+ _fieldOfStudy + "\n" + _graduationDate + "\n" + _GPA;
        }
    }
}
