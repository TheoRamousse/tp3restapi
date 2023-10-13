using System.Text.Json.Serialization;

namespace RestApi.Models.Dtos
{
    public class Page<T>
    {
        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("result")]
        public List<T> Result { get; set; }
    }
}
