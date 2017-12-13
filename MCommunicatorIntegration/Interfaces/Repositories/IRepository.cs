using System.Collections.Generic;

namespace MCommunicatorIntegration.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        // Changed to return the type we're inserting with an identity if necessary.
        void Insert(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetById(string id);
    }
}