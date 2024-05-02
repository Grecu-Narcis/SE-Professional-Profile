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

        public void addAdSet(AdSet adSetToAdd)
        {
            adSetRepository.addAdSet(adSetToAdd);

            adSetToAdd = adSetRepository.getAdSetByName(adSetToAdd);

            if (adSetToAdd == null)
            {
                return;
            }

            if (adSetToAdd.ads == null)
            {
                return;
            }

            foreach (Ad ad in adSetToAdd.ads)
            {
                adSetRepository.addAdToAdSet(adSetToAdd, ad);
            }
        }

        public void addAdToAdSet(AdSet adSet, Ad adToAdd)
        {
            this.adSetRepository.addAdToAdSet(adSet, adToAdd);
        }

        public void removeAdFromAdSet(AdSet adSet, Ad adToRemove)
        {
            this.adSetRepository.removeAdFromAdSet(adSet, adToRemove);
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

        public void updateAdSet(AdSet adSetToUpdate)
        {
            this.adSetRepository.updateAdSet(adSetToUpdate);
        }

        public void deleteAdSet(AdSet adSetToDelete)
        {
            this.adSetRepository.deleteAdSet(adSetToDelete);
        }
    }
}
