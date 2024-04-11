using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class User
    {
        private int user_id;
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

        public User(int user_id, string firstName, string lastName, string email, string password, string phone, string summary, DateTime dateOfBirth, bool darkTheme, string address, string websiteURL)
        {
            this.user_id = user_id;
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
        }

        public int User_id
        {
            get { return this.user_id; }
            set { this.user_id = value; }
        }

        public string FirstName
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }

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
            get { return this.DateOfBirth; }
            set { this.DateOfBirth = value; }
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

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   user_id == user.user_id &&
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
                   User_id == user.User_id &&
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
