using Newtonsoft.Json.Converters;
using RestApi.Models.Entities;
using System.Text.Json.Serialization;

namespace RestApi.Models.Dtos
{
    public class GuestDto : IDto<GuestEntity>
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime? BirthDate { get; set; }


        [JsonPropertyName("movies")]
        public List<MovieSimplifiedDto> Movies { get; set; } = new List<MovieSimplifiedDto>();


        public GuestEntity ToEntity()
        {
            var result =  new GuestEntity()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate,
            };

            Movies.ForEach(el =>
            {
                result.Relations.Add(new RelationEntity()
                {
                    GuestId = (int)el.Id,
                    MovieId = (int)this.Id
                });
            });
            return result;
        }
    }
}
