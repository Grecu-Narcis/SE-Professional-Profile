using Iss.Entity;
using Iss.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iss.User;

namespace Iss.Service
{
    internal class RequestService: IRequestService
    {
        private IRequestRepository requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public RequestService()
        {
            this.requestRepository = new RequestRepository();
        }

        public void addRequest(Request request)
        {
            this.requestRepository.addRequest(request);
        }

  
        public void deleteRequest(Request request)
        {
            this.requestRepository.deleteRequest(request);
        }

        public int getInfluencerId()
        {
            return this.requestRepository.getInfluencerId();
        }

        public List<Request> getRequestsForInfluencer()
        {
            return this.requestRepository.getRequestsForInfluencer();
        }

        public Request getRequestWithTitle(string title)
        {
            //parse the request list and find the request with given title

            List < Request > requestsList = this.requestRepository.getRequestsList();

            if(requestsList == null)
                return null;

            foreach (Request request in requestsList)
            {
                if (request.collaborationTitle == title)
                    return request;
            }
            return null;
        }

        public List<Request> getRequestsForAdAccount()
        {
            return this.requestRepository.getRequestsForAdAccount();
        }

        public void updateRequest(Request request, string newCompensation, string newContentRequirements)
        {
            request.compensation = newCompensation;
            request.contentRequirements = newContentRequirements;
            this.requestRepository.updateRequest(request);
        }
    }
}
