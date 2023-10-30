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


        public override async Task<RelationEntity?> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<RelationEntity>? GetAll()
        {
            return this._movieContext.Relations.AsQueryable() as IQueryable<RelationEntity>;
        }

        public override RelationEntity? Update(RelationEntity e)
        {
            _movieContext.Update(e);

            _movieContext.SaveChanges();

            return e;
        }
    }
}
