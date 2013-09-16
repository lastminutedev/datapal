using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataPal.Interfaces;
using DataPal.Models;

namespace DataPal.Repositories
{
    public class XTNAdsRepository : IRepository<XTNAd>
    {
        private SitesContext dataContext;

        public  XTNAdsRepository()
        {
            dataContext = new SitesContext();
        }

        public XTNAdsRepository(SitesContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(XTNAd item)
        {
            dataContext.XTNAds.Add(item);
            dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var itemFromDb = dataContext.XTNAds.FirstOrDefault(i => i.Id == id);
            dataContext.XTNAds.Remove(itemFromDb);

            dataContext.SaveChanges();
        }

        public IEnumerable<XTNAd> GetAll()
        {
            var items = dataContext.XTNAds;
            return items;
        }

        public XTNAd Get(int id)
        {
            var item = dataContext.XTNAds.FirstOrDefault(i => i.Id == id);
            return item;
        }

        public void Update(int id, XTNAd item)
        {
            var itemFromDb = dataContext.XTNAds.FirstOrDefault(i => i.Id == id);
            itemFromDb.Title = item.Title;
            itemFromDb.Text = item.Text;
            itemFromDb.LastModifiedDate = item.LastModifiedDate;
            
            dataContext.SaveChanges();
        }

        public IQueryable<XTNAd> Find(System.Linq.Expressions.Expression<Func<XTNAd, bool>> query)
        {
            throw new NotImplementedException();
        }
    }
}