﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class BasicSubscription : ISubscription
    {
        private int numberOfCampaigns {  get; set; }
        private decimal price { get; set; }
        private int reach { get; set; }

        public BasicSubscription(int numberOfCampaigns, decimal price, int reach)
        {
            this.numberOfCampaigns = numberOfCampaigns;
            this.price = price;
            this.reach = reach;
        }
        public int GetNumberOfCampaigns()
        {
            return numberOfCampaigns;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public int GetReach()
        {
            return reach;
        }
    }
}
