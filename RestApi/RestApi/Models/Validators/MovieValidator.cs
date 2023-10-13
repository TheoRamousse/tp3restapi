using RestApi.Models.Dtos;

namespace RestApi.Models.Validators
{
    public static class MovieValidator
    {
        public static IEnumerable<string> Validate(MovieDto movie)
        {
            if (string.IsNullOrEmpty(movie.Name))
            {
                yield return "Les nom du film est obligatoire ! ";
            }
            if (movie.ReleaseDate == null || movie.ReleaseDate == DateTime.MinValue)
            {
                yield return "La date de sortie du film est obligatoire ! ";
            }
            if (movie.Guests == null)
            {
                yield return "La liste des acteur est obligatoire même si elle est vide ! ";
            }
        }
    }
}
