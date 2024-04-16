using ProfessionalProfile.domain;
using ProfessionalProfile.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.business
{
    internal class AssessmentResultsService
    {
        private AssessmentResultRepo AssessmentResultRepo { get; }
        private AssessmentTestRepo AssessmentTestRepo { get; }

        public AssessmentResultsService()
        {
            AssessmentResultRepo = new AssessmentResultRepo();
            AssessmentTestRepo = new AssessmentTestRepo();
        }

        public List<AssessmentResult> getResultsByUserId(int userId)
        {
            return this.AssessmentResultRepo.GetAssessmentResultsByUserId(userId);
        }

        public AssessmentTest getTestById(int testId)
        {
            return this.AssessmentTestRepo.GetById(testId);
        }
    }
}
