using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SourceCodeStudio.Mobile.Services
{

    public class ShellNavigationService : INavigationService
    {
        public async Task Navigate(string page)
        {
            await Shell.Current.GoToAsync($"{page}");
        }

        public async Task Navigate<T>(string page, T value, string key = "Content")
        {
            var json = JsonConvert.SerializeObject(value);
            await Shell.Current.GoToAsync($"{page}?{key}={json}");
        }

        public async Task NavigateAndClearBackStack(string page)
        {
            await Shell.Current.GoToAsync($"//{page}");
        }

        public async Task NavigateAndClearBackStack<T>(string page, T value, string key = "Content")
        {
            var json = JsonConvert.SerializeObject(value);
            await Shell.Current.GoToAsync($"//{page}?{key}={json}");
        }

        public async Task PopAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
