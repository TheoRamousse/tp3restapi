namespace RestApi.Models.Entities
{
    public class MovieEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<GuestEntity> Guests { get; set; }
    }
}
