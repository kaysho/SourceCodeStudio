using Prism.Ioc;
using Refit;
using SourceCodeStudio.Mobile.Models;
using SourceCodeStudio.Mobile.Services;
using SourceCodeStudio.Mobile.ViewModels;
using SourceCodeStudio.Mobile.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Application = Xamarin.Forms.Application;

namespace SourceCodeStudio.Mobile.Bootstrap
{
    public static class AppContainer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="containerRegistry"></param>
        public static void RegisterDependencies(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<AboutPage, AboutViewModel>();
            containerRegistry.RegisterForNavigation<ItemDetailPage, ItemDetailViewModel>();
            containerRegistry.RegisterForNavigation<ItemsPage, ItemsViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterForNavigation<NewItemPage, NewItemViewModel>();
            containerRegistry.RegisterForNavigation<DogImagePage, DogImageViewModel>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomeViewModel>();

            containerRegistry.RegisterSingleton<INavigationService, ShellNavigationService>();
            containerRegistry.RegisterSingleton<ILocationService, LocationService>();
            containerRegistry.RegisterSingleton<IDataStore<Item>, MockDataStore>();
            containerRegistry.RegisterInstance(RestService.For<IRandomDogImageService>("https://dog.ceo/"));
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="app"></param>
        public static void SetUpApp(this Application app)
        {
            VersionTracking.Track();
            app.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            var theme = Preferences.Get("Theme", false);
            app.UserAppTheme = theme ? OSAppTheme.Dark : OSAppTheme.Light;
        }

        /// <summary>
        ///
        /// </summary>
        public static void RegisterPages()
        {
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(DogImagePage), typeof(DogImagePage));
        }
    }
}
