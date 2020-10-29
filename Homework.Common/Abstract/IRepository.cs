using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Common.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<TEntity> Delete(TEntity entity);

        DbContext GetDbContext();

    }
}
