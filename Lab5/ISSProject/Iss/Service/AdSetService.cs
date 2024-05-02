using Iss.Entity;
using Iss.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    public class AdSetService: IAdSetService
    {
        private IAdSetRepository adSetRepository;

        public AdSetService(IAdSetRepository adSetRepository)
        {
            this.adSetRepository = adSetRepository;
        }

        public AdSetService()
        {
            this.adSetRepository = new AdSetRepository();
        }

        public void addAdSet(AdSet adSet)
        {
            adSetRepository.addAdSet(adSet);

            adSet = adSetRepository.getAdSetByName(adSet);

            if (adSet == null)
            {
                return;
            }

            if (adSet.ads == null)
            {
                return;
            }

            foreach (Ad ad in adSet.ads)
            {
                adSetRepository.addAdToAdSet(adSet, ad);
            }
        }

        public void addAdToAdSet(AdSet adSet, Ad ad)
        {
            this.adSetRepository.addAdToAdSet(adSet, ad);
        }

        public void removeAdFromAdSet(AdSet adSet, Ad ad)
        {
            this.adSetRepository.removeAdFromAdSet(adSet, ad);
        }


        public List<AdSet> getAdSetsThatAreNotInCampaign()
        {
            return adSetRepository.getAdSetsThatAreNotInCampaign();
        }

        public List<AdSet> getAdSetsInCampaign(string id)
        {
            return adSetRepository.getAdSetsInCampaign(id);
        }

        public AdSet getAdSetByName(AdSet adSet)
        {
            return adSetRepository.getAdSetByName(adSet);
        }

        public void updateAdSet(AdSet adSet)
        {
            this.adSetRepository.updateAdSet(adSet);
        }

        public void deleteAdSet(AdSet adSet)
        {
            this.adSetRepository.deleteAdSet(adSet);
        }
    }
}
