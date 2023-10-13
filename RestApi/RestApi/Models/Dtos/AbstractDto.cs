using System.Text.Json.Serialization;

namespace RestApi.Models.Dtos
{
    public abstract class AbstractDto<T>
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        public abstract T ToEntity();

        public AbstractDto(int id)
        {
            Id = id;
        }
    }
}
