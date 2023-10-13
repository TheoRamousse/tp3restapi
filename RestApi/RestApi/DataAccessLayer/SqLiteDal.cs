using RestApi.Models.Contexts;
using RestApi.Models.Entities;

namespace RestApi.DataAccessLayer
{
    public abstract class SqLiteDal<T> : IDal<T> where T : class
    {
        private MovieContext _movieContext;
        public SqLiteDal(MovieContext context)
        {
            this._movieContext = context;
        }

        public async Task<T> Add(T el)
        {
            var result = await _movieContext.AddAsync<T>(el);
            _movieContext.SaveChanges();
            return result.Entity;
        }

        public T Remove(T el)
        {
            var result = _movieContext.Remove<T>(el);
            _movieContext.SaveChanges();
            return result.Entity;
        }

        public T Update(T el)
        {
            var result = _movieContext.Update<T>(el);
            _movieContext.SaveChanges();
            return result.Entity;
        }

        public T Delete(T el)
        {
            var result = _movieContext.Remove<T>(el);
            _movieContext.SaveChanges();
            return result.Entity;
        }

        public abstract Task<T?> GetOne(T el);

        public abstract IQueryable<T>? GetAll();
    }
}
