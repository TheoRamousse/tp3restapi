namespace RestApi.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public List<GuestDto> Guests { get; set; } = new List<GuestDto>();
    }
}
