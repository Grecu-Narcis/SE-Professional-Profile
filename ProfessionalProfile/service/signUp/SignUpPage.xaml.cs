using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Security.Cryptography;
using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
using ProfessionalProfile.service.login;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Web;
using System.Windows.Navigation;
using ProfessionalProfile.service.webBrowser;
using ProfessionalProfile.SectionViews;
using System.Diagnostics.Metrics;

namespace ProfessionalProfile.service.signUp
{
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Window
    {
      
        private UserRepo usersRepo;
        string clientIdLinkedin, redirectUrlLinkedin, clientSecretLinkedin, clientIdFacebook, redirectUrlFacebook, clientSecretFacebook;
        private bool hasExecuted = false;
        public SignUpPage()
        {
            InitializeComponent();
            this.usersRepo = new UserRepo();
            clientIdLinkedin = "77gmhbc7jwhfuu";
            redirectUrlLinkedin = "http://localhost:8000/lab2";
            clientSecretLinkedin = "3acj7wfj3kQDiHoB";
            clientIdFacebook = "968501770998125";
            redirectUrlFacebook = "http://localhost:8000/lab3";
            clientSecretFacebook = "9e46f4bab93249c84fa750eb6284c784";
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 0 || textBox.Text == "")
            {
                textBox.Text = "";
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
          TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Enter your email";
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            if (passwordBox.Password.Length > 0)
            {
                passwordPlaceholder.Visibility = Visibility.Collapsed;
            }
            else
            {
                passwordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void BirthDate_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "YYYY-MM-DD";
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void phoneBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PhoneBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Enter your number: +40";
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void PasswordPlaceholder_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordPlaceholder.Visibility = Visibility.Collapsed;
            passwordBox.Focus();
        }

       
        static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashedBytes = sha256.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2")); // Convert byte to hexadecimal string
                }
                return builder.ToString();
            }
        }

        private void handleSignUp(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text.Length == 0 || emailBox.Text.Length == 0 || passwordBox.Password.Length == 0 || dateBox.Text.Length == 0)
            {
                this.errorLabel.Content = "Please fill out every field!";
            }
            else
            {
                this.errorLabel.Content = "";
                this.errorLabel.Visibility = Visibility.Collapsed;
                string[] name = this.nameBox.Text.Split(' ');
                string password = ComputeSHA256Hash(this.passwordBox.Password);
                string phoneNr = this.phoneBox.Text;
                string about = this.descBox.Text;
                // the user ID doesn't get processed in the add procedure, and an automatic ID is generated instead
                User newUser = new User(0, name[0], String.Join(" ",name.Skip(1).ToArray()), emailBox.Text,password,phoneNr,about,DateTime.Parse(this.dateBox.Text),false,"","","");

                this.usersRepo.Add(newUser);

                User loggedInUser = null;
                List<User> users = this.usersRepo.GetAll();
                foreach (User user in users)
                {
                    if(user.Email == newUser.Email) 
                    {
                        loggedInUser = user;
                        break;
                    }
                }

                CertificateWindow window = new CertificateWindow(loggedInUser.UserId);
                this.Hide();
                window.Show();

                //this.Hide();
                //LoginPage loginPage = new LoginPage();
                //loginPage.Show();


                //this.titleBox.Text = String.Join(" - ", usersRepo.GetAll().Select(e => e.FirstName + " " + e.LastName + " " + e.Email + " " + e.Password + " " + e.DateOfBirth + "\n").ToList());
            }

        }

        

        private void facebookSignUp(object sender, RoutedEventArgs e)
        {
            string scope = "email public_profile";
            HttpClient httpClient = new HttpClient();

            string authorizationUrl = $"https://www.facebook.com/v12.0/dialog/oauth?client_id={clientIdFacebook}&redirect_uri={redirectUrlFacebook}&scope={scope}";

            BrowserPage browserPage = new BrowserPage(false);
            browserPage.webBrowser.Navigate("about:blank");
            browserPage.webBrowser.Navigate(authorizationUrl);
            this.Hide();
            browserPage.Show();


        }


        private void LinkedInLogin(object sender, RoutedEventArgs e)
        {
            // Construct the OAuth authorization URL for LinkedIn
            string authorizationUrl = "https://www.linkedin.com/oauth/v2/authorization";
            string clientId = "77gmhbc7jwhfuu"; // Replace with your LinkedIn Client ID
            string redirectUri = "http://localhost:8000"; // Replace with your LinkedIn Redirect URI
            string scope = "profile openid email"; // Add any additional LinkedIn scopes as needed
            // Construct the full authorization URL with parameters

            string fullAuthorizationUrl = $"{authorizationUrl}?response_type=code&client_id={this.clientIdLinkedin}&redirect_uri={redirectUrlLinkedin}&scope={scope}";

            // Navigate to the authorization URL in the embedded web browser control
            BrowserPage browserPage = new BrowserPage(false);
            //this.Hide();
            browserPage.webBrowser.Navigate("about:blank");
            browserPage.webBrowser.Navigate(fullAuthorizationUrl);
            browserPage.Show();



        }

       
    }

}
