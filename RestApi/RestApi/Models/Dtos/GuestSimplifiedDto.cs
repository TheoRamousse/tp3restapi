using Newtonsoft.Json.Converters;
using RestApi.Models.Entities;
using System.Text.Json.Serialization;

namespace RestApi.Models.Dtos
{
    public class GuestSimplifiedDto
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime? BirthDate { get; set; }


        [JsonPropertyName("role")]
        public RoleDto Role { get; set; }

    }
}
