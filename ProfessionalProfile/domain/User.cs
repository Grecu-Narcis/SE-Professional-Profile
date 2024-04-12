using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class User
    {
        private int _userId;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _phone;
        private string _summary;
        private DateTime _dateOfBirth;
        private bool _darkTheme;
        private string _address;
        private string _websiteURL;
        private string _picture;

        public User(int userId, string firstName, string lastName, string email, string password, string phone, string summary, DateTime dateOfBirth, bool darkTheme, string address, string websiteURL, string picture)
        {
            this._userId = userId;
            this._firstName = firstName;
            this._lastName = lastName;
            this._email = email;
            this._password = password;
            this._phone = phone;
            this._summary = summary;
            this._dateOfBirth = dateOfBirth;
            this._darkTheme = darkTheme;
            this._address = address;
            this._websiteURL = websiteURL;
            this._picture = picture;
        }

        public int UserId   {  get { return this._userId; } set { this._userId = value; }   }

        public string FirstName{ get { return this._firstName; }set { this._firstName = value; } }

        public string LastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }
        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }
        public string Phone
        {
            get { return this._phone; }
            set { this._phone = value; }
        }
        public string Summary
        {
            get { return this._summary; }
            set { this._summary = value; }
        }
        public DateTime DateOfBirth
        {
            get { return this._dateOfBirth; }
            set { this._dateOfBirth = value; }
        }
        public bool DarkTheme
        {
            get { return this._darkTheme; }
            set { this._darkTheme = value; }
        }
        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }
        public string WebsiteURL
        {
            get { return this._websiteURL; }
            set { this._websiteURL = value; }
        }

        public string Picture{
            get { return this._picture; }
            set { this._picture = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   _userId == user._userId &&
                   _firstName == user._firstName &&
                   _lastName == user._lastName &&
                   _email == user._email &&
                   _password == user._password &&
                   _phone == user._phone &&
                   _summary == user._summary &&
                   _dateOfBirth == user._dateOfBirth &&
                   _darkTheme == user._darkTheme &&
                   _address == user._address &&
                   _websiteURL == user._websiteURL &&
                   _picture == user._picture &&
                   Picture == user.Picture &&
                   UserId == user.UserId &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName &&
                   Email == user.Email &&
                   Password == user.Password &&
                   Phone == user.Phone &&
                   Summary == user.Summary &&
                   DateOfBirth == user.DateOfBirth &&
                   DarkTheme == user.DarkTheme &&
                   Address == user.Address &&
                   WebsiteURL == user.WebsiteURL;
        }
    }
}
