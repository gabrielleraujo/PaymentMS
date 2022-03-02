using Microsoft.EntityFrameworkCore;
using PaymentMS.Data.Context;

namespace PaymentMS.Infrastructure.Data.Repository
{
	public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected readonly PaymentMSContext context;
		protected DbSet<T> dbSet;

        public BaseRepository(PaymentMSContext dbContext)
        {
			context = dbContext;
			dbSet = context.Set<T>();
        }

		public async Task AddAsync(T entity)
		{
			await dbSet.AddAsync(entity);
		}

		public async Task<IList<T>> ListAsync()
		{
			return await dbSet.ToListAsync();
		}

		public async Task<T> GetAsync(Func<T, bool> predicate)
		{
			return dbSet.Where(predicate).FirstOrDefault();
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await dbSet.FindAsync(id);
		}

		public async Task Commit()
		{
			await context.SaveChangesAsync();
		}
	}
}