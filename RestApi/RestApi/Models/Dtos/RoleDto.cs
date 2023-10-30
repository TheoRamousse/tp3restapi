using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RestApi.Models.Dtos
{
    public enum RoleDto
    {
        [EnumMember(Value = "realisator")]
        Realisator,
        [EnumMember(Value = "actor")]
        Actor
    }
}
