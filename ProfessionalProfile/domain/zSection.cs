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
        private int _section_id;
        private string _status;

        public zSection(int section_id, string status) { 
            this._section_id = section_id;
            this._status = status;
        }

        public int Section_id
        {
            get { return _section_id; }
            set { _section_id = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is zSection section &&
                   _section_id == section._section_id &&
                   _status == section._status &&
                   Section_id == section.Section_id &&
                   Status == section.Status;
        }
    }
}
