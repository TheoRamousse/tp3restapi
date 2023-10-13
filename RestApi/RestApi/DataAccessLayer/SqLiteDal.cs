using RestApi.Models.Contexts;

namespace RestApi.DataAccessLayer
{
    public class SqLiteDal<T> : IDal<T> where T : class
    {
        private MovieContext _movieContext;
        public SqLiteDal(MovieContext context)
        {
            this._movieContext = context;
        }

        public T Add(T el)
        {
            var result = _movieContext.Add<T>(el);
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
    }
}
