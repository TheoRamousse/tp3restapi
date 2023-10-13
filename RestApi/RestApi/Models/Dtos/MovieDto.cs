using System.Text.Json.Serialization;

namespace RestApi.Models.Dtos
{
    public class MovieDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("guests")]
        public List<GuestDto> Guests { get; set; } = new List<GuestDto>();
    }
}
