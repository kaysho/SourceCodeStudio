using System.Threading.Tasks;

namespace SourceCodeStudio.Mobile.Services
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigate to a page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Task Navigate(string page);

        /// <summary>
        /// Navigate to a  page and send object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task Navigate<T>(string page, T value, string key = "Content");

        /// <summary>
        /// Navigate to a page and clear the entire back stack
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Task NavigateAndClearBackStack(string page);

        /// <summary>
        /// Navigate to a page and clear the entire back stack
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page"></param>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task NavigateAndClearBackStack<T>(string page, T value, string key = "Content");

        /// <summary>
        /// Pop back to the previous page
        /// </summary>
        /// <returns></returns>
        Task PopAsync();
    }
}
