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

        public override async Task<MovieEntity?> GetOne(MovieEntity el)
        {
            return await _movieContext.FindAsync<MovieEntity>(new int[] { (int)el.Id });
        }

        public override IQueryable<MovieEntity>? GetAll()
        {
            return this._movieContext.Movies.AsQueryable() as IQueryable<MovieEntity>;
        }
    }
}
