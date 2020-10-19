using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.Esame.Finale.Models;

namespace Vendrame.Esame.Finale.Data
{
    public interface IRepository<TEntity, TKey>
               where TEntity : EntityBase<TKey>
    {
        IEnumerable<TEntity> GetAll(string sigla);

        TEntity Get(TKey id);

        void Insert(TEntity entity);

        void Update(int id);

        void Delete(TKey id);

        int Count();
    }
}
