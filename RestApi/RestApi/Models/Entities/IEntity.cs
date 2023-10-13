namespace RestApi.Models.Entities
{
    public interface IEntity<T>
    {
        public T ToDto();
    }
}
