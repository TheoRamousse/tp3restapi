using RestApi.Models.Entities;
using System.Text.Json.Serialization;

namespace RestApi.Models.Dtos
{
    public class MovieDto: AbstractDto<MovieEntity>
    {
        public MovieDto(int id) : base(id)
        {
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("guests")]
        public List<GuestDto> Guests { get; set; } = new List<GuestDto>();


        public override MovieEntity ToEntity()
        {
            return new MovieEntity()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Guests = this.Guests.Select(g => g.ToEntity()).ToList()
            };
        }
    }
}
