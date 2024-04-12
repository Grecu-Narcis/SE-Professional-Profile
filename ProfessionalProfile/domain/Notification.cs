namespace ProfessionalProfile.domain
{
    public class Notification
    {
        private int _notificationId;
        private int _userId;
        private string _activity;
        private DateTime _timestamp;
        private string _details;
        private bool _isRead;

        public Notification(int notificationId, int userId, string activity, DateTime timestamp, string details, bool isRead)
        {
            this._notificationId = notificationId;
            this._userId = userId;
            this._activity = activity;
            this._timestamp = timestamp;
            this._details = details;
            this._isRead = isRead;
        }

        public int NotificationId{
            get { return _notificationId; }
            set {  _notificationId = value; }
        }

        public int UserId { get { return _userId; }
        set { _userId = value; }
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

        public bool IsRead
        {
            get { return this._isRead; }
            set { this._isRead = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Notification notification &&
                   _notificationId == notification._notificationId &&
                   _userId == notification._userId &&
                   _activity == notification._activity &&
                   _timestamp == notification._timestamp &&
                   _details == notification._details &&
                   _isRead == notification._isRead &&
                   NotificationId == notification.NotificationId &&
                   UserId == notification.UserId &&
                   Activity == notification.Activity &&
                   Timestamp == notification.Timestamp &&
                   Details == notification.Details &&
                   IsRead == notification.IsRead;
        }
    }
}
