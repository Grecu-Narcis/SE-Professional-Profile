using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.SectionExceptions
{
    public class CustomSectionException: Exception
    {
        public CustomSectionException()
        {
        }

        public CustomSectionException(string message)
            : base(message)
        {
        }

        public CustomSectionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
