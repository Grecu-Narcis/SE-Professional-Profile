using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    class Endorsement
    {
        private int _endorsement_id;
        private int _endorser_id;
        private int _recipient_id;
        private int _skill_id;

        public Endorsement(int endorsement_id, int endorser_id, int recipient_id, int skill_id)
        {
            this._endorsement_id = endorsement_id;
            this._endorser_id = endorser_id;
            this._recipient_id = recipient_id;
            this._skill_id = skill_id;
        }

        public int Endorsement_id
        {
            get { return _endorsement_id; }

            set { _endorsement_id = value; }
        }

        public int Edorser_id
        {
            get { return _endorser_id; }
            set { _endorser_id = value;}
        }

        public int Recipient_id
        {
            get { return _recipient_id; }
            set { this._recipient_id = value; }
        }

        public int Skill_id
        {
            get { return _skill_id; }
            set { _skill_id = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Endorsement endorsement &&
                   _endorsement_id == endorsement._endorsement_id &&
                   _endorser_id == endorsement._endorser_id &&
                   _recipient_id == endorsement._recipient_id &&
                   _skill_id == endorsement._skill_id &&
                   Endorsement_id == endorsement.Endorsement_id &&
                   Edorser_id == endorsement.Edorser_id &&
                   Recipient_id == endorsement.Recipient_id &&
                   Skill_id == endorsement.Skill_id;
        }
    }
}
