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
    internal class CollaborationTests
    {
        [Test]
        public void Constructor_WithAllParameters_CorrectInitialization()
        {
            // Arrange
            int collaborationId = 1;
            DateTime startDate = new DateTime(2022, 4, 1);
            bool status = true;
            string contentRequirement = "Content requirement";
            string adOverview = "Ad overview";
            string collaborationFee = "100";
            int days = 7;
            string collaborationTitle = "Collaboration Title";

            // Act
            Collaboration collaboration = new Collaboration(collaborationId, startDate, status, contentRequirement, adOverview, collaborationFee, days, collaborationTitle);

            // Assert
            Assert.AreEqual(collaborationId, collaboration.CollaborationId);
            Assert.AreEqual(startDate, collaboration.startDate);
            Assert.AreEqual(status, collaboration.status);
            Assert.AreEqual(contentRequirement, collaboration.contentRequirement);
            Assert.AreEqual(adOverview, collaboration.adOverview);
            Assert.AreEqual(collaborationFee, collaboration.collaborationFee);
            Assert.AreEqual(startDate.AddDays(days), collaboration.endDate);
        }

        [Test]
        public void Constructor_WithSelectedParameters_CorrectInitialization()
        {
            // Arrange
            string collaborationTitle = "Collaboration Title";
            string adOverview = "Ad overview";
            string collaborationFee = "100";
            string contentRequirement = "Content requirement";
            DateTime startDate = new DateTime(2022, 4, 1);
            DateTime endDate = new DateTime(2022, 4, 8);
            bool status = true;

            // Act
            Collaboration collaboration = new Collaboration(collaborationTitle, adOverview, collaborationFee, contentRequirement, startDate, endDate, status);

            // Assert
            Assert.AreEqual(collaborationTitle, collaboration.collaborationTitle);
            Assert.AreEqual(adOverview, collaboration.adOverview);
            Assert.AreEqual(collaborationFee, collaboration.collaborationFee);
            Assert.AreEqual(contentRequirement, collaboration.contentRequirement);
            Assert.AreEqual(startDate, collaboration.startDate);
            Assert.AreEqual(endDate, collaboration.endDate);
            Assert.AreEqual(status, collaboration.status);
        }


    }
}
