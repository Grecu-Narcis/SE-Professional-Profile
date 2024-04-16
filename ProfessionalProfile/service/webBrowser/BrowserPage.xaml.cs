using ProfessionalProfile.domain;
using ProfessionalProfile.profile_page;
using ProfessionalProfile.repo;
using ProfessionalProfile.SectionViews;
using ProfessionalProfile.service.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProfessionalProfile.service.webBrowser
{
    /// <summary>
    /// Interaction logic for BrowserPage.xaml
    /// </summary>
    public partial class BrowserPage : Window
    {
        private UserRepo usersRepo;
        string clientIdLinkedin, redirectUrlLinkedin, clientSecretLinkedin, clientIdFacebook, redirectUrlFacebook, clientSecretFacebook;
        private bool hasExecuted, login;

        public BrowserPage(bool login)
        {
            InitializeComponent();
            this.usersRepo = new UserRepo();
            clientIdLinkedin = "77gmhbc7jwhfuu";
            redirectUrlLinkedin = "http://localhost:8000/lab2";
            clientSecretLinkedin = "3acj7wfj3kQDiHoB";
            clientIdFacebook = "968501770998125";
            redirectUrlFacebook = "http://localhost:8000/lab3";
            clientSecretFacebook = "9e46f4bab93249c84fa750eb6284c784";
            hasExecuted = false;
            this.login = login;
            //clear the cache
            
        }

        private async void webBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.Uri.AbsoluteUri.StartsWith(redirectUrlLinkedin) && !hasExecuted)
            {
                hasExecuted = true;
                // Extract authorization code from the query parameters
                var queryParams = HttpUtility.ParseQueryString(e.Uri.Query);
                string code = queryParams["code"];

                // Exchange authorization code for access token
                string tokenEndpoint = "https://www.linkedin.com/oauth/v2/accessToken";
                HttpClient httpClient = new HttpClient();
                var tokenRequest = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "code", code },
            { "client_id", clientIdLinkedin },
            { "client_secret", clientSecretLinkedin },
            { "redirect_uri", redirectUrlLinkedin }
        });

                HttpResponseMessage response = await httpClient.PostAsync(tokenEndpoint, tokenRequest);
                string responseContent = await response.Content.ReadAsStringAsync();
                // Deserialize JSON response
                JsonDocument doc = JsonDocument.Parse(responseContent);
                JsonElement root = doc.RootElement;

                // Access the "access_token" property
                string accessToken = root.GetProperty("access_token").GetString();
                string scope = root.GetProperty("scope").GetString();

                await Console.Out.WriteLineAsync(accessToken);

                // Now you have the access token, you can use it to make API requests
                // For example, you can call the GetEmailAddress method passing the accessToken
                if (!login)
                     await SignUpLinkedinUser(accessToken);
                else
                    await AuthenticateLinkedinUser(accessToken);



            }

            if (e.Uri.AbsoluteUri.StartsWith(redirectUrlFacebook) && !hasExecuted)
            {
                hasExecuted = true;
                // Extract authorization code from the query parameters
                var queryParams = HttpUtility.ParseQueryString(e.Uri.Query);
                string code = queryParams["code"];

                // Exchange authorization code for access token
                string tokenEndpoint = "https://graph.facebook.com/v12.0/oauth/access_token";
                HttpClient httpClient = new HttpClient();
                var tokenRequest = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "code", code },
            { "client_id", clientIdFacebook },
            { "client_secret", clientSecretFacebook },
            { "redirect_uri", redirectUrlFacebook }
        });

                HttpResponseMessage response = await httpClient.PostAsync(tokenEndpoint, tokenRequest);
                string responseContent = await response.Content.ReadAsStringAsync();
                // Deserialize JSON response
                JsonDocument doc = JsonDocument.Parse(responseContent);
                JsonElement root = doc.RootElement;

                // Access the "access_token" property
                string accessToken = root.GetProperty("access_token").GetString();




                // Now you have the access token, you can use it to make API requests
                if (!login)
                     await SignUpFacebookUser(accessToken);
                else
                    await AuthenticateUserFacebook(accessToken);





            }

            // Check if the navigation URL contains "platform.linkedin.com" (or any other domain you want to block)

            if (e.Uri.Host.Contains("platform.linkedin.com") || e.Uri.Host.Contains("static.licdn.com/"))
            {
                // Cancel the navigation
                e.Cancel = true;
                
            }
         

        }

        public async Task<User> SignUpLinkedinUser(string accessToken)
        {
            string apiUrl = "https://api.linkedin.com/v2/userinfo";


            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Optional: ignore case when deserializing properties
                };

                var jDoc = JsonDocument.Parse(responseBody).RootElement;
                string email = jDoc.GetProperty("email").ToString();


                User newUser = new User(0, jDoc.GetProperty("given_name").ToString(), jDoc.GetProperty("family_name").ToString(), jDoc.GetProperty("email").ToString(), accessToken, "", "", DateTime.Parse("2010-10-10"), false, jDoc.GetProperty("locale").GetProperty("country").ToString(), "", jDoc.GetProperty("picture").ToString());
                this.usersRepo.Add(newUser);


                // AICI IN LOC DE LOGINPAGE, mergem la pagina principala, puteti lua newUser.userId pentru a customiza pagina
                //LoginPage loginPage = new LoginPage();
                //this.Hide();
                //loginPage.titleBox.Text = "Welcome back " + newUser.FirstName + newUser.LastName + newUser.Email + newUser.Address + newUser.Picture;
                //loginPage.Show();
                User loggedInUser = null;
                List<User> allUsers = this.usersRepo.GetAll();
                foreach (var user in allUsers)
                {
                    if (user.Email == email)
                    {
                        loggedInUser = (User)user;
                        break;
                    }
                }

                CertificateWindow window = new CertificateWindow(loggedInUser.UserId);             
                this.Hide();
                window.Show();

                return newUser;

            }
            else
            {
                // Handle error
                return null;
            }
        }
        public async Task<User> SignUpFacebookUser(string accessToken)
        {
            string apiUrl = $"https://graph.facebook.com/me?fields=id,name,email,about,birthday,cover&access_token={accessToken}"; // Specify the fields you want to retrieve


            HttpClient httpClient = new HttpClient();


            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Optional: ignore case when deserializing properties
                };

                var jDoc = JsonDocument.Parse(responseBody).RootElement;
                string email = jDoc.GetProperty("email").ToString();

                string[] name = jDoc.GetProperty("name").ToString().Split(" ");
                string[] birthday = jDoc.GetProperty("birthday").ToString().Split("/");



                User newUser = new User(0, name[0], name[1], jDoc.GetProperty("email").ToString(), accessToken, "", "", DateTime.Parse($"{birthday[2]}-{birthday[0]}-{birthday[1]}"), false, "", "", "");
                try
                {
                    this.usersRepo.Add(newUser);
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.ToString());
                }

                // AICI IN LOC DE LOGINPAGE, mergem la pagina principala, puteti lua newUser.userId pentru a customiza pagina
                //LoginPage loginPage = new LoginPage();
                //this.Hide();
                //loginPage.titleBox.Text = "Welcome back " + newUser.FirstName + newUser.LastName + newUser.Email + newUser.Address + newUser.Picture;
                //loginPage.Show();
                User loggedInUser = null;
                List<User> allUsers = this.usersRepo.GetAll();
                foreach (var user in allUsers)
                {
                    if (user.Email == email)
                    {
                        loggedInUser = (User)user;
                        break;
                    }
                }

                CertificateWindow window = new CertificateWindow(loggedInUser.UserId);
                this.Hide();
                window.Show();


                return newUser;
            }
            else
            {
                // Handle error
                return null;
            }
        }
        public async Task<User> AuthenticateLinkedinUser(string accessToken)
        {
            string apiUrl = "https://api.linkedin.com/v2/userinfo";


            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Optional: ignore case when deserializing properties
                };

                var jDoc = JsonDocument.Parse(responseBody).RootElement;
                string email = jDoc.GetProperty("email").ToString();


                User newUser = new User(0, jDoc.GetProperty("given_name").ToString(), jDoc.GetProperty("family_name").ToString(), jDoc.GetProperty("email").ToString(), accessToken, "", "", DateTime.Parse("2010-10-10"), false, jDoc.GetProperty("locale").GetProperty("country").ToString(), "", jDoc.GetProperty("picture").ToString());

                User loggedInUser = null;
                List<User> allUsers = this.usersRepo.GetAll();
                foreach (var user in allUsers)
                {
                    if (user.Email == email)
                    {
                        loggedInUser = (User)user;
                        break;
                    }
                }

                if (loggedInUser == null)
                {
                    this.errorLabel.Visibility = Visibility.Visible;
                    this.errorLabel.Content = "No user found with that user and password! Please sign in!";

                }
                else
                {
                    //this.errorLabel.Content = "Welcome back " + loggedInUser.FirstName + loggedInUser.LastName + loggedInUser.Email + loggedInUser.Address + loggedInUser.Picture;
                    //this.errorLabel.Foreground = Brushes.Green;
                    //CertificateWindow window = new CertificateWindow(loggedInUser.UserId) ;
                    ProfilePage window = new ProfilePage(loggedInUser.UserId, loggedInUser.UserId);
                    this.Hide();
                    window.Show();
                }

                return loggedInUser;
            }
            else
            {
                // Handle error
                return null;
            }
        }

        public async Task<User> AuthenticateUserFacebook(string accessToken)
        {
            string apiUrl = $"https://graph.facebook.com/me?fields=id,name,email,about,birthday,cover&access_token={accessToken}"; // Specify the fields you want to retrieve


            HttpClient httpClient = new HttpClient();


            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Optional: ignore case when deserializing properties
                };

                var jDoc = JsonDocument.Parse(responseBody).RootElement;
                string email = jDoc.GetProperty("email").ToString();

                string[] name = jDoc.GetProperty("name").ToString().Split(" ");
                string[] birthday = jDoc.GetProperty("birthday").ToString().Split("/");



                User newUser = new User(0, name[0], name[1], jDoc.GetProperty("email").ToString(), accessToken, "", "", DateTime.Parse($"{birthday[2]}-{birthday[0]}-{birthday[1]}"), false, "", "", "");

                User loggedInUser = null;
                List<User> allUsers = this.usersRepo.GetAll();
                foreach (var user in allUsers)
                {
                    if (user.Email == email)
                    {
                        loggedInUser = (User)user;
                        break;
                    }
                }

                if (loggedInUser == null)
                {
                    this.errorLabel.Visibility = Visibility.Visible;
                    this.errorLabel.Content = "No user found with that user and password! Please sign in!";
                }
                else
                {
                    ProfilePage window = new ProfilePage(loggedInUser.UserId, loggedInUser.UserId);
                    //CertificateWindow window = new CertificateWindow(loggedInUser.UserId);
                    this.Hide();
                    window.Show();
                }

                return newUser;
            }
            else
            {
                // Handle error
                return null;
            }
        }
    }
}
