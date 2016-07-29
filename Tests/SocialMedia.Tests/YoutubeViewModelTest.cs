using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamarinForms.ViewModels;

namespace SocialMedia.Tests
{
    [TestClass]
    public class YoutubeViewModelTest
    {
        [TestMethod]
        public async Task YoutubeTest()
        {
            // Arrange
            var youtubeViewModel = new YoutubeViewModel();

            // Act
            await youtubeViewModel.InitDataAsync();

            // Arrange
            Assert.IsNotNull(youtubeViewModel.YoutubeItems);
            Assert.IsTrue(youtubeViewModel.YoutubeItems.Count > 0);
        }
    }
}
