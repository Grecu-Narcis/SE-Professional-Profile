using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    class Certification
    {
        private int _cert_id;
        private string _name;
        private string _issuingOrganisation;
        private DateTime _issuanceDate;
        private DateTime _expirationDate;
        private int _user_id;

        public Certification(int cert_id, string name, string issuingOrganisation, DateTime issuanceDate, DateTime expirationDate, int user_id)
        {
            this._cert_id = cert_id;
            this._name = name;
            this._issuingOrganisation = issuingOrganisation;
            this._issuanceDate = issuanceDate;
            this._expirationDate = expirationDate;
            this._user_id = user_id;
        }

        public int Cert_id
        {
            get { return this._cert_id; }
            set { this._cert_id = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string IssuingOrganisation
        { 
            get { return this._issuingOrganisation;}
            set { this._issuingOrganisation = value; }
        }

        public DateTime IssuanceDate
        {
            get { return this._issuanceDate; }
            set { this._issuanceDate = value; }
        }

        public DateTime ExpirationDate
        {
            get { return this._expirationDate; }
            set { this._expirationDate = value; }
        }

        public int User_id
        {
            get { return this._user_id; }
            set { this._user_id = value;}
        }

        public override bool Equals(object? obj)
        {
            return obj is Certification certification &&
                   _cert_id == certification._cert_id &&
                   _name == certification._name &&
                   _issuingOrganisation == certification._issuingOrganisation &&
                   _issuanceDate == certification._issuanceDate &&
                   _expirationDate == certification._expirationDate &&
                   _user_id == certification._user_id &&
                   Cert_id == certification.Cert_id &&
                   Name == certification.Name &&
                   IssuingOrganisation == certification.IssuingOrganisation &&
                   IssuanceDate == certification.IssuanceDate &&
                   ExpirationDate == certification.ExpirationDate &&
                   User_id == certification.User_id;
        }
    }
}
