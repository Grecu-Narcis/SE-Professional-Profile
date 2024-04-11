using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    // NOT USED
    class StatusType
    {
        private int _status_id;
        private string _status;

        public StatusType(int status_id, string status)
        {
            this._status_id = status_id;
            this._status = status;
        }

        public int Status_id
        {
            get { return _status_id; }
            set { _status_id = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is StatusType type &&
                   _status_id == type._status_id &&
                   _status == type._status &&
                   Status_id == type.Status_id &&
                   Status == type.Status;
        }
    }
}
