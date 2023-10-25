using FluentAssertions;
using Moq;
using SourceCodeStudio.Mobile.Services;
using SourceCodeStudio.Mobile.ViewModels;
using Xunit;

namespace SourceCodeStudio.Mobile.UnitTest
{
    public class DogImageViewModelShould
    {

        private readonly Mock<IRandomDogImageService> mockRandomImageService;
        private readonly Mock<INavigationService> mockNavigationService;
        private readonly DogImageViewModel sut;
        public DogImageViewModelShould()
        {
            mockRandomImageService = new Mock<IRandomDogImageService>();
            mockNavigationService = new Mock<INavigationService>();
            sut = new DogImageViewModel(mockNavigationService.Object, mockRandomImageService.Object);
        }

        [Fact]
        public void LoadDogImageSuccessfully()
        {
            //Arrange
            var dogImageResponse = new Models.DogResponse { Message = "https://images.dog.ceo/breeds/mix/archie_02.jpg", Status = "success" };
            mockRandomImageService.Setup(n => n.GetRandomImage()).ReturnsAsync(dogImageResponse);
            //Act
            sut.FetchImageCommand.Execute(null);
            //Assert
            sut.ImageUrl.Should().Be(dogImageResponse.Message);
        }
        [Fact]
        public void NavigateToPreviousPageSuccessfully()
        {
            //Arrange

            //Act
            sut.CloseCommand.Execute(null);
            //Assert
            mockNavigationService.Verify(n => n.PopAsync(), Times.Once);
        }
    }
}
