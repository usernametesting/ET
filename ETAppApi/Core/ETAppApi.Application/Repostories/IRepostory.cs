using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETAppApi.Application.Repostories
{
    public interface IRepostory<TEntity> where TEntity : class
    {
        public DbSet<TEntity> entity{ get; }
    }
}
