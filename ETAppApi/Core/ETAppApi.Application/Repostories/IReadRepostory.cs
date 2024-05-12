using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETAppApi.Application.Repostories
{
    public interface IReadRepostory<TEntity> : IRepostory<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetWhere(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> GetAll();

        Task SaveAsync();
    }
}
