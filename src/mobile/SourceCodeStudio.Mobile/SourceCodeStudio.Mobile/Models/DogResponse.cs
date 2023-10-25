using Newtonsoft.Json;

namespace SourceCodeStudio.Mobile.Models
{
    public class DogResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
