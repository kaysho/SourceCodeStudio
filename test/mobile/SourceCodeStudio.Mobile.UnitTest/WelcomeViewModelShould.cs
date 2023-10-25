using FluentAssertions;
using Moq;
using SourceCodeStudio.Mobile.Services;
using SourceCodeStudio.Mobile.ViewModels;
using SourceCodeStudio.Mobile.Views;
using System;
using System.Threading;
using Xunit;

namespace SourceCodeStudio.Mobile.UnitTest
{
    public class WelcomeViewModelShould
    {
        private readonly Mock<ILocationService> mockLocationService;
        private readonly Mock<INavigationService> mockNavigationService;
        private readonly WelcomeViewModel sut;
        public WelcomeViewModelShould()
        {
            mockLocationService = new Mock<ILocationService>();
            mockNavigationService = new Mock<INavigationService>();
            sut = new WelcomeViewModel(mockNavigationService.Object, mockLocationService.Object);
        }

        [Fact]
        public void RetrieveLocationSuccessfully()
        {
            //Arrange
            string address = "Bury St Edmunds";
            mockLocationService.Setup(n => n.GetLocation(It.IsAny<CancellationTokenSource>())).ReturnsAsync(address);
            //Act
            sut.LocationCommand.Execute(null);
            //Assert
            sut.Address.Should().Be(address);
        }

        [Fact]
        public void HandlePermissionException()
        {
            //Arrange
            mockLocationService.Setup(n => n.GetLocation(It.IsAny<CancellationTokenSource>())).Throws(new Exception());
            //Act
            sut.LocationCommand.Execute(null);
            //Assert
            sut.Address.Should().Be(null);
        }

        [Fact]
        public void NavigateToNextPageSuccessfully()
        {
            //Arrange

            //Act
            sut.NavigateToNextPageCommand.Execute(null);
            //Assert
            mockNavigationService.Verify(n => n.Navigate(nameof(DogImagePage)), Times.Once);
        }
    }
}
