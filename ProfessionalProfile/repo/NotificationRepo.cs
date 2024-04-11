using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class NotificationRepo : RepoInterface<Notification>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public void Add(Notification item)
        {
        }

        public void Delete(int id)
        {
        }

        public Notification Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetAll()
        {
            List<Notification> notifications= new List<Notification>();
            return notifications;
        }

        public void Update(Notification entity)
        {
        }
    }
}
