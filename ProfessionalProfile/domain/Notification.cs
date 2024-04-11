namespace ProfessionalProfile.domain
{
    public class Notification
    {
        private int _notification_id;
        private int _user_id;
        private string _activity;
        private DateTime _timestamp;
        private string _details;
        private bool _read;

        public Notification(int notif_id, int user_id, string activity, DateTime timestamp, string details, bool read)
        {
            this._notification_id = notif_id;
            this._user_id = user_id;
            this._activity = activity;
            this._timestamp = timestamp;
            this._details = details;
            this._read = read;
        }

        public int Notif_id{
            get { return _notification_id; }
            set {  _notification_id = value; }
        }

        public int User_id { get { return _user_id; }
        set { _user_id = value; }
        }

        public string Activity { 
            get { return _activity; }
            set { _activity = value; }
        }

        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }

        public bool Read
        {
            get { return this._read; }
            set { this._read = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Notification notification &&
                   _notification_id == notification._notification_id &&
                   _user_id == notification._user_id &&
                   _activity == notification._activity &&
                   _timestamp == notification._timestamp &&
                   _details == notification._details &&
                   _read == notification._read &&
                   Notif_id == notification.Notif_id &&
                   User_id == notification.User_id &&
                   Activity == notification.Activity &&
                   Timestamp == notification.Timestamp &&
                   Details == notification.Details &&
                   Read == notification.Read;
        }
    }
}
