using Newtonsoft.Json;

namespace PRN231_LeQuocUy_FrontEnd.DTO
{
    public class OdataResponse<T>
    {
        [JsonProperty("value")]
        public List<T> Value { get; set; }

        [JsonProperty("@odata.count")]
        public int Count { get; set; }
    }
}
