using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    //NOT USED
    public class zSection
    {
        private int _sectionId;
        private string _status;

        public zSection(int sectionId, string status) { 
            this._sectionId = sectionId;
            this._status = status;
        }

        public int SectionId
        {
            get { return _sectionId; }
            set { _sectionId = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is zSection section &&
                   _sectionId == section._sectionId &&
                   _status == section._status &&
                   SectionId == section.SectionId &&
                   Status == section.Status;
        }
    }
}
