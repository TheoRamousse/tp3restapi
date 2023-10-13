namespace RestApi.DataAccessLayer
{
    public interface IDal<T>
    {
        public T Add(T el);

        public T Remove(T el);

        public T Update(T el);

        public T Delete(T el);
    }
}
