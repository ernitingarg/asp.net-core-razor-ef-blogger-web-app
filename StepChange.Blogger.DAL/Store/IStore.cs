using System.Collections.Generic;
using System.Threading.Tasks;

namespace StepChange.Blogger.DAL.Store
{
    /// <summary>
    /// Provide methods to manipulate an object in Db.
    /// </summary>
    /// <typeparam name="T">Object Type</typeparam>
    /// <typeparam name="TKey">Primary Key Type</typeparam>
    internal interface IStore<T, TKey>
    {
        Task CreateAsync(T data);
        Task UpdateAsync(T data);
        Task DeleteAsync(T data);
        Task<T> FindById(TKey id);
        Task<HashSet<TKey>> GetIds();
    }
}
