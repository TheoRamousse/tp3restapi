using Newtonsoft.Json.Converters;
using RestApi.Models.Entities;
using System.Text.Json.Serialization;

namespace RestApi.Models.Dtos
{
    public class GuestDto : AbstractDto<GuestEntity>
    {
        public GuestDto(int id) : base(id)
        {
        }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }


        [JsonPropertyName("role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Role Role { get; set; }


        public override GuestEntity ToEntity()
        {
            return new GuestEntity()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate
            };
        }
    }
}
