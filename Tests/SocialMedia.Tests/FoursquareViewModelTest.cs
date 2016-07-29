using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamarinForms.ViewModels;

namespace SocialMedia.Tests
{
    [TestClass]
    public class FoursquareViewModelTest
    {
        [TestMethod]
        public async Task FoursquareTest()
        {
            // Arrange
            var foursquareViewModel = new FoursquareViewModel();

            // Act
            await foursquareViewModel.InitDataAsync();

            // Arrange
            Assert.IsNotNull(foursquareViewModel.FoursquareVenues);
            //Assert.IsTrue(foursquareViewModel.FoursquareVenues.Count > 0);
        }
    }
}
