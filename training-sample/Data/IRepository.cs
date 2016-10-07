using System.Collections.Generic;

namespace training_sample.Data
{
    public interface IRepository<T>
    {
        T Get(string id);
        IEnumerable<T> GetAll();
        T Create(string id, T item);
        T Update(string id, T item);
        T Delete(string id);
        string NextId();
    }
}