using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public interface IAdRepository
    {
        public void addAd(Ad ad);
        public Ad getAdByName(string adName);
        public List<Ad> getAdsThatAreNotInAdSet();
        public List<Ad> getAdsForAdSet(string id);
        public void updateAd(Ad ad);
        public void deleteAd(Ad ad);
    }
}
