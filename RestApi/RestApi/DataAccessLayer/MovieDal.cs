using Microsoft.EntityFrameworkCore;
using RestApi.Models.Contexts;
using RestApi.Models.Entities;

namespace RestApi.DataAccessLayer
{
    public class MovieDal : SqLiteDal<MovieEntity>
    {
        private MovieContext _movieContext;
        public MovieDal(MovieContext context) : base(context)
        {
            this._movieContext = context;
        }

        public override async Task<MovieEntity?> GetOne(int id)
        {
            return await _movieContext.Movies.Include(p => p.Relations).ThenInclude(p => p.Guest).AsQueryable().FirstOrDefaultAsync(el => el.Id == id); ;
        }

        public override IQueryable<MovieEntity>? GetAll()
        {
            return this._movieContext.Movies.Include(p => p.Relations).ThenInclude(p => p.Guest).AsQueryable() as IQueryable<MovieEntity>;
        }

        public override MovieEntity? Update(MovieEntity e)
        {

            _movieContext.Update(e);

            _movieContext.SaveChanges();

            return e;
        }
    }
}
