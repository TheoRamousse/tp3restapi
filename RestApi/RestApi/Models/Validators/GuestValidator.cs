using RestApi.Models.Dtos;

namespace RestApi.Models.Validators
{
    public static class GuestValidator
    {
        public static IEnumerable<string> Validate(GuestDto guest)
        {
            if (string.IsNullOrEmpty(guest.FirstName))
            {
                yield return "Les prénom de l'artiste est obligatoire ! ";
            }
            if (guest.BirthDate == null || guest.BirthDate == DateTime.MinValue)
            {
                yield return "La date de naissance de l'artiste est obligatoire ! ";
            }
            if (string.IsNullOrEmpty(guest.LastName))
            {
                yield return "Le nom de l'artiste est obligatoire ! ";
            }
            if (guest.Movies == null)
            {
                yield return "La liste des films est obligatoire même si elle est vide ! ";
            }
        }
    }
}
