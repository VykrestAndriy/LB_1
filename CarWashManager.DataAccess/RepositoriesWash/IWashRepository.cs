using System.Collections.ObjectModel;
using CarWashManager.DataAccess.Entities;

namespace CarWashManager.DataAccess.Repositories.Order;

public interface IWashRepository
{
    public Task<ReadOnlyCollection<WashEntity>> Get();
    public Task<WashEntity?> Get(string id);
    public Task<ReadOnlyCollection<WashEntity>> Get(Func<WashEntity, bool> predicate);
    public Task Create(WashEntity entity);
    public Task Update(WashEntity entity);
    public Task Delete(string WashId);
}