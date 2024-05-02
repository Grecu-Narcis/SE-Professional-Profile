using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class AdSet
    {
        public string adSetId { get; set; }
        public string name { get; set; }
        public List<Ad> ads { get;  set; }
        public string targetAudience { get; set; }

        public AdSet(string id, string name, List<Ad> ads, string targetAudience)
        {
            this.adSetId = id;
            this.name = name;
            this.ads = ads;
            this.targetAudience = targetAudience;
        }

        public AdSet(string adSetId, string name, string targetAudience)
        {
            this.adSetId = adSetId;
            this.name = name;
            this.targetAudience = targetAudience;
        }

        public AdSet(string name, string targetAudience, List<Ad> ads)
        {
            this.ads = ads;
            this.name = name;
            this.targetAudience = targetAudience;
        }

        public void addAd(Ad adToAdd)
        {
            ads.Add(adToAdd);
        }

        public void removeAd(Ad adToRemove)
        {
            ads.Remove(adToRemove);
        }

        public override string ToString()
        {
            return "ADSET NAME: " + name + "-" + "TARGET AUDIENCE: " + targetAudience;
        }
    }
}
