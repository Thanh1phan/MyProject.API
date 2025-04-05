using MyProject.API.Data.Entities;

namespace MyProject.API.Repository.IRepository
{
    public interface IK11TRepository : IRepository<K11T>
    {
        K11T Update(K11T entity);
    }
}
