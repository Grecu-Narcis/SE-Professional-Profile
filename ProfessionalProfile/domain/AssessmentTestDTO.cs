using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class AssessmentTestDTO
    {
        public String TestName {  get; set; }
        public String Description { get; set; }
        public List<QuestionDTO> questions { get; set; }
        public String SkillTested { get; set; }

        public AssessmentTestDTO(String  TestName, String Description, List<QuestionDTO> questions, string skillTested)
        {
            this.TestName = TestName;
            this.Description = Description;
            this.questions = questions;
            SkillTested=skillTested;
        }
    }
}
