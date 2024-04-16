using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class Certificate
    {
        private int _certificateId;
        private string _name;
        private string _issuedBy;
        private string _description;
        private DateTime _issuedDate;
        private DateTime _expirationDate;
        private int _userId;

        public Certificate(int certificateId, int userId, string name, string issuedBy,string description, DateTime issuedDate, DateTime expirationDate)
        {
            this._certificateId = certificateId;
            this._name = name;
            this._issuedBy = issuedBy;
            this._description = description;
            this._issuedDate = issuedDate;
            this._expirationDate = expirationDate;
            this._userId = userId;
        }

        public int CertificateId
        {
            get { return this._certificateId; }
            set { this._certificateId = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string IssuedBy
        { 
            get { return this._issuedBy;}
            set { this._issuedBy = value; }
        }

        public DateTime IssuedDate
        {
            get { return this._issuedDate; }
            set { this._issuedDate = value; }
        }

        public DateTime ExpirationDate
        {
            get { return this._expirationDate; }
            set { this._expirationDate = value; }
        }

        public int UserId
        {
            get { return this._userId; }
            set { this._userId = value;}
        }

        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Certificate certification &&
                   _certificateId == certification._certificateId &&
                   _name == certification._name &&
                   _issuedBy == certification._issuedBy &&
                   _description == certification._description &&
                   _issuedDate == certification._issuedDate &&
                   _expirationDate == certification._expirationDate &&
                   _userId == certification._userId &&
                   CertificateId == certification.CertificateId &&
                   Name == certification.Name &&
                   IssuedBy == certification.IssuedBy &&
                   Description == certification.Description &&
                   IssuedDate == certification.IssuedDate &&
                   ExpirationDate == certification.ExpirationDate &&
                   UserId == certification.UserId;
        }

        public override string ToString()
        {
            return _name + "\n" + _description + "\n" + _issuedBy + "\n" + _issuedDate + "\n" + _expirationDate;
        }
    }
}
