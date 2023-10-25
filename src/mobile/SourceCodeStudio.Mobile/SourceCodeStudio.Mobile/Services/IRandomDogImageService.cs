using Refit;
using SourceCodeStudio.Mobile.Models;
using System.Threading.Tasks;

namespace SourceCodeStudio.Mobile.Services
{
    public interface IRandomDogImageService
    {
        [Get("/api/breeds/image/random")]
        Task<DogResponse> GetRandomImage();
    }
}
