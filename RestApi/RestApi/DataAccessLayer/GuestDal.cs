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

        public override async Task<GuestEntity?> GetOne(GuestEntity el)
        {
            return await _movieContext.FindAsync<GuestEntity>(new int[] { (int)el.Id });
        }

        public override IQueryable<GuestEntity>? GetAll()
        {
            return this._movieContext.Guests.AsQueryable() as IQueryable<GuestEntity>;
        }
    }
}
