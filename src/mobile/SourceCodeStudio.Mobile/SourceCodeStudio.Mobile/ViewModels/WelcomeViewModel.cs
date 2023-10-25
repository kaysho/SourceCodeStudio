using SourceCodeStudio.Mobile.Services;
using SourceCodeStudio.Mobile.Views;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace SourceCodeStudio.Mobile.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public CancellationTokenSource cts;

        public ICommand LocationCommand { get; set; }
        public string Address { get; set; }
        public ICommand NavigateToNextPageCommand { get; set; }
        private readonly ILocationService locationService;
        public WelcomeViewModel(INavigationService navigationService, ILocationService locationService) : base(navigationService: navigationService)
        {
            Title = "Welcome";
            NavigateToNextPageCommand = new Command(ExecuteNextPageCommand);
            LocationCommand = new Command(ExecuteLocationCommand);
            this.locationService = locationService;
        }

        private async void ExecuteLocationCommand(object obj)
        {
            try
            {
                cts = new CancellationTokenSource();
                Address = await locationService.GetLocation(cts);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void ExecuteNextPageCommand(object obj) => await navigationService.Navigate(nameof(DogImagePage));
    }
}
