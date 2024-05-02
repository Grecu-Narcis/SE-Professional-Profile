using Iss.Entity;
using Iss.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Iss.Tests.Repository
{
    public class AdRepositoryTests
    {
        [Fact]
        public void AddAd_WhenCalled_InsertsAndDeletesAdFromDatabase()
        {
            // Arrange
            var adRepository = new AdRepository("1");

            var ad = new Ad("TestProductName", "test.jpg", "TestDescription", "https://example.com");

            // Act
            adRepository.addAd(ad);

            // Assert
            var addedAd = adRepository.getAdByName("TestProductName");
            Assert.NotNull(addedAd);
            Assert.Equal("TestProductName", addedAd.productName);
            Assert.Equal("test.jpg", addedAd.photo);
            Assert.Equal("TestDescription", addedAd.description);
            Assert.Equal("https://example.com", addedAd.websiteLink);

            // Act (Delete the ad)
            adRepository.deleteAd(ad);

            // Assert
            var deletedAd = adRepository.getAdByName("TestProductName");
            Assert.Null(deletedAd);
        }

        [Fact]
        public void UpdateAd_WhenCalled_UpdatesAdInDatabase()
        {
            // Arrange
            var adRepository = new AdRepository("1");

            // Create a new ad and add it to the database
            var ad = new Ad("TestProductName", "test.jpg", "TestDescription", "https://example.com");
            adRepository.addAd(ad);
            ad.id = adRepository.getAdByName("TestProductName").id;

            // Modify the ad
            ad.photo = "updated_test.jpg";
            ad.description = "Updated TestDescription";
            ad.websiteLink = "https://updated-example.com";

            // Act
            adRepository.updateAd(ad);

            // Assert
            // Retrieve the updated ad from the database
            var updatedAd = adRepository.getAdByName("TestProductName");

            // Check if the ad was updated correctly
            Assert.NotNull(updatedAd);
            Assert.Equal("TestProductName", updatedAd.productName);
            Assert.Equal("updated_test.jpg", updatedAd.photo);
            Assert.Equal("Updated TestDescription", updatedAd.description);
            Assert.Equal("https://updated-example.com", updatedAd.websiteLink);

            // Cleanup (Delete the ad)
            adRepository.deleteAd(updatedAd);
        }

        [Fact]
        public void GetAdByName_ExistingName_ReturnsAd()
        {
            // Arrange
            var adRepository = new AdRepository();
            var adName = "ExistingAdName";

            // Act
            var result = adRepository.getAdByName(adName);

            // Assert
            // Assert that result is not null and has the correct name
            Assert.NotNull(result);
            Assert.Equal(adName, result.productName);
        }

        [Fact]
        public void GetAdByName_NonExistingName_ReturnsNull()
        {
            // Arrange
            var adRepository = new AdRepository();
            var adName = "NonExistingAdName";

            // Act
            var result = adRepository.getAdByName(adName);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetAdsThatAreNotInAdSet_WhenCalled_ReturnsAds()
        {
            // Arrange
            var adRepository = new AdRepository("1");

            // Act
            var result = adRepository.getAdsThatAreNotInAdSet();

            // Assert
            // Assert that result is not null and has the expected number of ads
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetAdsForAdSet_ExistingId_ReturnsAds()
        {
            // Arrange
            var adRepository = new AdRepository("1");
            var adSetId = "1";

            // Act
            var result = adRepository.getAdsForAdSet(adSetId);

            // Assert
            // Assert that result is not null and has the expected number of ads
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetAdsForAdSet_NonExistingId_ReturnsEmptyList()
        {
            // Arrange
            var adRepository = new AdRepository("1");
            var adSetId = "0";

            // Act
            var result = adRepository.getAdsForAdSet(adSetId);

            // Assert
            // Assert that result is not null and is an empty list
            Assert.NotNull(result);
            Assert.Empty(result);
        }



    }
}
