using System.Text.Json.Serialization;

namespace RestApi.Models.Dtos
{
    public interface IDto<T>
    {

        public abstract T ToEntity();

    }
}
