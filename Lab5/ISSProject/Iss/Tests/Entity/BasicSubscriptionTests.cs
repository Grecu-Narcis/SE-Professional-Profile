using Iss.Entity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;



namespace Iss.Tests.Entity
{
    [TestFixture]
    internal class BasicSubscriptionTests
    {
        [Test]
        public void BasicSubscription_Constructor_CorrectInitialization()
        {
            // Arrange
            int expectedNumberOfCampaigns = 5;
            decimal expectedPrice = 99.99m;
            int expectedReach = 10000;

            // Act
            BasicSubscription subscription = new BasicSubscription(expectedNumberOfCampaigns, expectedPrice, expectedReach);

            // Assert
            Assert.AreEqual(expectedNumberOfCampaigns, subscription.GetNumberOfCampaigns());
            Assert.AreEqual(expectedPrice, subscription.GetPrice());
            Assert.AreEqual(expectedReach, subscription.GetReach());
        }

    }
}
