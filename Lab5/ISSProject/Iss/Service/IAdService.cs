using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    internal interface IAdService
    {
        public void addAd(Ad ad);
        public List<Ad> getAdsThatAreNotInAdSet();
        public void updateAd(Ad ad);
        public Ad getAdByName(string adName);
        public void deleteAd(Ad ad);
        public List<Ad> GetAdsFromAdSet(string id);

    }
}
