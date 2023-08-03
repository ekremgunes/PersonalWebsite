
using gunesekremcom.Data.Context;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Interfaces;
using gunesekremcom.Data.Iuow;
using gunesekremcom.Data.Repository;

namespace gunesekremcom.Data.Uow
{
    public class Uow : IUow
    {
        private readonly DatabaseContext context;

        public Uow(DatabaseContext context)
        {
            this.context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity, new()
        {
            return new Repository<T>(context);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
