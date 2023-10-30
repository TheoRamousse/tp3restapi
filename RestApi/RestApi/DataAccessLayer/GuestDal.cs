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
            return await _movieContext.Guests.Include(p => p.Relations).ThenInclude(p => p.Movie).AsQueryable().FirstOrDefaultAsync(el => el.Id == id);
        }

        public override IQueryable<GuestEntity>? GetAll()
        {
            return this._movieContext.Guests.Include(p => p.Relations).ThenInclude(p => p.Movie).AsQueryable() as IQueryable<GuestEntity>;
        }


        public override GuestEntity? Update(GuestEntity e)
        {
            
            _movieContext.Update(e);

            _movieContext.SaveChanges();

            return e;
        }
    }
}
