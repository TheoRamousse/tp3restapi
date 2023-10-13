using System.Text.Json.Serialization;

namespace RestApi.Models.Dtos
{
    public class Info
    {
        [JsonPropertyName("nextPage")]
        public int NextPage { get; set; }

        [JsonPropertyName("previousPage")]
        public int PreviousPage { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }
    }
}
