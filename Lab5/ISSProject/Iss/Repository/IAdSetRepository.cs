using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public interface IAdSetRepository
    {
        public void addAdSet(AdSet adSet);
        public void deleteAdSet(AdSet adSet);
        public void updateAdSet(AdSet adSet);
        public AdSet getAdSetByName(AdSet adSet);
        public void addAdToAdSet(AdSet adSet, Ad ad);
        public void removeAdFromAdSet(AdSet adSet, Ad ad);
        public List<AdSet> getAdSetsThatAreNotInCampaign();
        public List<AdSet> getAdSetsInCampaign(string id);
    }
}
