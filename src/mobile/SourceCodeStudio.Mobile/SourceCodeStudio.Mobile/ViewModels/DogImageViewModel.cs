using SourceCodeStudio.Mobile.Services;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace SourceCodeStudio.Mobile.ViewModels
{
    public class DogImageViewModel : BaseViewModel
    {
        private readonly IRandomDogImageService randomDogImageService;
        public string ImageUrl { get; set; }
        public ICommand FetchImageCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public DogImageViewModel(INavigationService navigationService, IRandomDogImageService randomDogImageService) : base(navigationService: navigationService)
        {
            this.randomDogImageService = randomDogImageService;
            FetchImageCommand = new Command(ExecuteFetchImageCommand);
            CloseCommand = new Command(ExecuteCloseCommand);
        }

        private async void ExecuteCloseCommand(object obj) => await navigationService.PopAsync();

        private async void ExecuteFetchImageCommand(object obj)
        {
            try
            {
                var dogImageResponse = await randomDogImageService.GetRandomImage();
                if (dogImageResponse.Status == "success")
                {
                    ImageUrl = dogImageResponse.Message;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
