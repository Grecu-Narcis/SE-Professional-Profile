using ProfessionalProfile.domain;
using ProfessionalProfile.SectionExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.SectionValidators
{
    public class SectionValidator
    {
        public static void validateCertificate(Certificate certificate)
        {
            if (certificate.IssuedDate > DateTime.Now)
                throw new CustomSectionException("Date of issuance is in the future!");
            if (certificate.IssuedDate > certificate.ExpirationDate)
                throw new CustomSectionException("Date of issuance is after the expiration date!");
        }

        public static void validateEducation(Education education)
        {
            if (education.GPA < 0 || education.GPA > 4)
                throw new CustomSectionException("GPA is out of range!");
            if (education.GraduationDate > DateTime.Now)
                throw new CustomSectionException("Graduation date is in the future!");
        }

        public static void validateWorkExperience(WorkExperience workExperience)
        {
            string[] dates = workExperience.EmploymentPeriod.Split(" to ");

            // Ensure that there are two dates
            if (dates.Length != 2)
            {
                throw new CustomSectionException("Date Format must be in format \"YYYYY-MM-DD to YYYY-MM-DD\" !");
            }

            // Try parsing the dates
            if (!DateTime.TryParse(dates[0], out DateTime startDate) || !DateTime.TryParse(dates[1], out DateTime endDate))
            {
                throw new CustomSectionException("Date Format must be in format \"YYYYY-MM-DD to YYYY-MM-DD\" !");
            }

            // Ensure that the start date is before or equal to the end date
            if (startDate > endDate)
            {
                throw new CustomSectionException("Start date is after the end date!");
            }
        }
    }
}
