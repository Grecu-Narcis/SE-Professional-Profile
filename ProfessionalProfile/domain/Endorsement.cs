using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.domain
{
    public class Endorsement
    {
        private int _endorsementId;
        private int _endorserId;
        private int _recipient_id;
        private int _skillId;

        public Endorsement(int endorsementId, int endorser_id, int recipient_id, int skillId)
        {
            this._endorsementId = endorsementId;
            this._endorserId = endorser_id;
            this._recipient_id = recipient_id;
            this._skillId = skillId;
        }

        public int EndorsementId
        {
            get { return _endorsementId; }

            set { _endorsementId = value; }
        }

        public int EdorserId
        {
            get { return _endorserId; }
            set { _endorserId = value;}
        }

        public int RecipientId
        {
            get { return _recipient_id; }
            set { this._recipient_id = value; }
        }

        public int SkillId
        {
            get { return _skillId; }
            set { _skillId = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Endorsement endorsement &&
                   _endorsementId == endorsement._endorsementId &&
                   _endorserId == endorsement._endorserId &&
                   _recipient_id == endorsement._recipient_id &&
                   _skillId == endorsement._skillId &&
                   EndorsementId == endorsement.EndorsementId &&
                   EdorserId == endorsement.EdorserId &&
                   RecipientId == endorsement.RecipientId &&
                   SkillId == endorsement.SkillId;
        }
    }
}
