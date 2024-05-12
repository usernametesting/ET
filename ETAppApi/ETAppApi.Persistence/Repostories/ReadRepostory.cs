using ETAppApi.Application.Repostories;
using ETAppApi.Domain.Entities.Common;
using ETAppApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETAppApi.Persistence.Repostories
{
    public class ReadRepostory<TEntity> : IReadRepostory<TEntity> where TEntity : BaseEntity
    {
        public DbSet<TEntity> entity { get; set; }

        public ETAppContext context { get; }

        public ReadRepostory(ETAppContext context)
        {
            this.context = context;
            entity = this.context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id) =>
            await entity.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<TEntity>> GetWhere(Expression<Func<TEntity, bool>> expression) =>
           await entity.Where(expression).ToListAsync();

        public IQueryable<TEntity> GetAll() =>
            entity;

        public async Task SaveAsync() =>
     await context.SaveChangesAsync();
    }
}
