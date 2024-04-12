using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    // NOT USED
    public class StatusType
    {
        private int _statusId;
        private string _status;

        public StatusType(int statusId, string status)
        {
            this._statusId = statusId;
            this._status = status;
        }

        public int StatusId
        {
            get { return _statusId; }
            set { _statusId = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is StatusType type &&
                   _statusId == type._statusId &&
                   _status == type._status &&
                   StatusId == type.StatusId &&
                   Status == type.Status;
        }
    }
}
