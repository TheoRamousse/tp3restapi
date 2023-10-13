using RestApi.Models.Contexts;
using RestApi.Models.Entities;

namespace RestApi.DataAccessLayer
{
    public class RelationDal : SqLiteDal<RelationEntity>
    {
        private MovieContext _movieContext;
        public RelationDal(MovieContext context) : base(context)
        {
            this._movieContext = context;
        }


        public override async Task<RelationEntity?> GetOne(RelationEntity el)
        {
            return await _movieContext.FindAsync<RelationEntity>(new int[] { (int)el.GuestsId, (int)el.MoviesId });
        }

        public override IQueryable<RelationEntity>? GetAll()
        {
            return this._movieContext.Relations.AsQueryable() as IQueryable<RelationEntity>;
        }
    }
}
