﻿namespace RestApi.DataAccessLayer
{
    public interface IDal<T>
    {
        public Task<T> Add(T el);

        public T Remove(T el);

        public T Update(T el);

        public T Delete(T el);

        public Task<T?> GetOne(T el);

        public IQueryable<T>? GetAll();
    }
}
