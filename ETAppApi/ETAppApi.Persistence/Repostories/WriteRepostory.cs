using ETAppApi.Application.Repostories;
using ETAppApi.Domain.Entities.Common;
using ETAppApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETAppApi.Persistence.Repostories
{
    public class WriteRepostory<TEntity> : IWriteRepostory<TEntity> where TEntity : BaseEntity
    {
        public DbSet<TEntity> entity { get; set; }

        public ETAppContext context { get; }

        public WriteRepostory(ETAppContext context)
        {
            this.context = context;
            entity = this.context.Set<TEntity>();
        }

        public async Task<bool> AddAsync(TEntity item)
        {
           var result =  await entity.AddAsync(item);
            return result.State == EntityState.Added;
        }

        public async Task<bool> Remove(TEntity item)
        {
            var res = entity.Remove(item);
            return res.State == EntityState.Deleted;
        }

        public bool UpdateAsync(TEntity item)
        {
            var res = entity.Update(item);
            return res.State == EntityState.Modified;
        }
    }
}
