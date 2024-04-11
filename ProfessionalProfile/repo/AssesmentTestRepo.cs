using ProfessionalProfile.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.repo
{
    public class AssesmentTestRepo : RepoInterface<AssesmentTest>
    {
       
        public AssesmentTest Get(int id)
        {
            AssesmentTest assesmentTest = new AssesmentTest();
            return assesmentTest;
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
