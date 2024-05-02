using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public interface IRequestRepository
    {
        public int getInfluencerId();
        public void addRequest(Request request);
        public List<Request> getRequestsForInfluencer();
        public void deleteRequest(Request request);
        public List<Request> getRequestsList();
        public List<Request> getRequestsForAdAccount();
        public void updateRequest(Request request);
    }
}
