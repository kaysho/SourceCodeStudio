using System.Threading;
using System.Threading.Tasks;

namespace SourceCodeStudio.Mobile.Services
{
    public interface ILocationService
    {
        Task<string> GetLocation(CancellationTokenSource cts);
    }
}
