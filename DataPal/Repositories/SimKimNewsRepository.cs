using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataPal.Filters;
using DataPal.Interfaces;
using DataPal.Models;

namespace DataPal.Repositories
{
    public class SimKimNewsRepository : IRepository<SimKimNews>
    {
        private SitesContext dataContext;

        public SimKimNewsRepository()
        {
            dataContext = new SitesContext();
        }

        public SimKimNewsRepository(SitesContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(SimKimNews item)
        {
            dataContext.SimKimNews.Add(item);
            dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var itemFromDb = dataContext.SimKimNews.FirstOrDefault(i => i.Id == id);
            dataContext.SimKimNews.Remove(itemFromDb);

            dataContext.SaveChanges();
        }
    
        public IEnumerable<SimKimNews> GetAll()
        {
            var items = dataContext.SimKimNews;
            return items;
        }

        public SimKimNews Get(int id)
        {
            var item = dataContext.SimKimNews.FirstOrDefault(i => i.Id == id);
            return item;
        }

        public void Update(int id, SimKimNews item)
        {
            var itemFromDb = dataContext.SimKimNews.FirstOrDefault(i => i.Id == id);
            itemFromDb.Title = item.Title;
            itemFromDb.Text = item.Text;
            itemFromDb.LastModifiedDate = item.LastModifiedDate;

            dataContext.SaveChanges();
        }

        public IQueryable<SimKimNews> Find(System.Linq.Expressions.Expression<Func<SimKimNews, bool>> query)
        {
            throw new NotImplementedException();
        }
    }
}
