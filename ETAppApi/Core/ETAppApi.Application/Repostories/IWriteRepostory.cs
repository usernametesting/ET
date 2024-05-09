using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETAppApi.Application.Repostories
{
    public interface IWriteRepostory<TEntity> :IRepostory<TEntity> where TEntity : class
    {
        Task<bool> AddAsync(TEntity item);
        bool UpdateAsync(TEntity item);
        Task<bool> Remove(TEntity item);

    }
}
