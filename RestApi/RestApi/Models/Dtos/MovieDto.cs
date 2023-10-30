using RestApi.Models.Entities;
using System.Text.Json.Serialization;

namespace RestApi.Models.Dtos
{
    public class MovieDto: IDto<MovieEntity>
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("releaseDate")]
        public DateTime? ReleaseDate { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("guests")]
        public List<GuestSimplifiedDto>? Guests { get; set; } = new List<GuestSimplifiedDto>();


        public MovieEntity ToEntity()
        {
            var result = new MovieEntity()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                ReleaseDate = this.ReleaseDate,
            };

            Guests.ForEach(g =>
            {
                result.Relations.Add(new RelationEntity()
                {
                    GuestId = (int)g.Id,
                    MovieId = (int)Id,
                    Role = (int)g.Role,

                });


            });

            return result;
        }
    }
}
