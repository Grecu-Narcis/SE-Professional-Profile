using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class AssesmentTest : RepoInterface<AssesmentTest>
    {
        public void Add(AssesmentTest item)
        {
        }

        public void Delete(int id)
        {
        }

        public List<AssesmentTest> GetAll()
        {
            List<AssesmentTest> assesmentTests = new List<AssesmentTest>();

            return assesmentTests;
        }

        public AssesmentTest GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AssesmentTest item)
        {
        }
    }
}
