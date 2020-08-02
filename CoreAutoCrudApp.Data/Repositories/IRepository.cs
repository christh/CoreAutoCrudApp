using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using CoreAutoCrudApp.Data.Models;

namespace CoreAutoCrudApp.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void Add(params T[] items);
        void Update(params T[] items);
        void Delete(params T[] items);
    }
    public interface IAssetRepository : IRepository<Asset>
    {
    }

}
