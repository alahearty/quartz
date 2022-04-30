using Quartz.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quartz.Application.Interfaces
{
    public interface IRepository<T> where T:EntityBase
    {
        void Save(T entity);
        Task SaveAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        T GetById(int id);
        IList<T> GetAll();
        void Delete(T entity);
        Task DeleteAsync(T entity);
    }    
}
