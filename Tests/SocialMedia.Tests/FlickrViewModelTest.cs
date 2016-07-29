using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamarinForms.ViewModels;

namespace SocialMedia.Tests
{
    [TestClass]
    public class FlickrViewModelTest
    {
        [TestMethod]
        public async Task FlickrTest()
        {
            // Arrange
            var flickrViewModel = new FlickrViewModel();

            // Act
            await flickrViewModel.InitDataAsync();

            // Arrange
            Assert.IsNotNull(flickrViewModel.FlickrItems);
            Assert.IsTrue(flickrViewModel.FlickrItems.Count > 0);
        }
    }
}
