using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace RestApi.Models.Dtos
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoleDto
    {
        Realisator,
        Actor
    }
}
