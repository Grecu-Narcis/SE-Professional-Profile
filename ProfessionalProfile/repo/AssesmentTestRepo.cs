using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class AssesmentTestRepo : RepoInterface<AssesmentTest>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public AssesmentTest Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<AssesmentTest> GetAll()
        {
            List<AssesmentTest> assesmentTests = new List<AssesmentTest>();
            return assesmentTests;
        }

        public void Add(AssesmentTest item)
        {
        }

        public void Delete(int id)
        {
        }

        public void Update(AssesmentTest entity)
        {
        }
    }
}
