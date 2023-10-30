using Microsoft.EntityFrameworkCore;
using RestApi.Models.Contexts;
using RestApi.Models.Entities;

namespace RestApi.DataAccessLayer
{
    public class GuestDal : SqLiteDal<GuestEntity>
    {
        private MovieContext _movieContext;
        public GuestDal(MovieContext context) : base(context)
        {
            this._movieContext = context;
        }

        public override async Task<GuestEntity?> GetOne(int id)
        {
            return _movieContext.Guests.AsNoTracking().Single(p => p.Id == id);
        }

        public override IQueryable<GuestEntity>? GetAll()
        {
            return this._movieContext.Guests.AsQueryable() as IQueryable<GuestEntity>;
        }


        public override GuestEntity? Update(GuestEntity e)
        {
            /*List<int?> listOfActorsId = e.Movies.Select(g => g.Id).ToList();

            e.Movies.Clear();

            e.Movies.AddRange(_movieContext.Movies.AsQueryable().Where(g => listOfActorsId.Contains(g.Id)).AsEnumerable());*/

            _movieContext.Update(e);

            _movieContext.SaveChanges();

            return e;
        }
    }
}
