using RestApi.Models.Contexts;
using RestApi.Models.Entities;

namespace RestApi.DataAccessLayer
{
    public class SqLiteDal<T> : IDal<T> where T : class
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

        public async Task<T?> GetOne(int id)
        {
            return await _movieContext.FindAsync<T>(new int[] { id });
        }

        public IQueryable<T>? GetAll()
        {
            if(typeof(T) is GuestEntity)
            {
                return this._movieContext.Guests.AsQueryable() as IQueryable<T>;
            }
            else
            {
                return this._movieContext.Movies.AsQueryable() as IQueryable<T>;
            }
        }
    }
}
