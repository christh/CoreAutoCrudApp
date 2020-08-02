using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using CoreAutoCrudApp.Data.Contexts;
using CoreAutoCrudApp.Data.Models;
using System.Linq;
using CoreAutoCrudApp.Data.Pagination;
using System.Threading.Tasks;

namespace CoreAutoCrudApp.Data.Repositories
{
    public class AssetRepository : IRepository<Asset>
    {
        #region Get Assets methods
        public async Task<PagedResult<Asset>> GetPagedAssetsOverview(int page, int pageSize)
        {
            using (var context = new AssetContext())
            {
                var paged = await context.Assets.GetPagedAsync(page, pageSize);
                return paged;
            }
        }

        public async Task<Asset> GetById(Guid id)
        {
            using (var context = new AssetContext())
            {
                return await context.Assets.FindAsync(id);
            }
        }
        #endregion

        #region Example BLL methods
        public void Add(params Asset[] items)
        {
            throw new NotImplementedException();
        }

        public IList<Asset> GetAll(params Expression<Func<Asset, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<Asset> GetList(Func<Asset, bool> where, params Expression<Func<Asset, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public Asset GetSingle(Func<Asset, bool> where, params Expression<Func<Asset, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Delete(params Asset[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params Asset[] items)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
