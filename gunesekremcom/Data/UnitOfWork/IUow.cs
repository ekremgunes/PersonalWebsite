using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Interfaces;

namespace gunesekremcom.Data.Iuow
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity, new();
        Task SaveChangesAsync();
    }
}
