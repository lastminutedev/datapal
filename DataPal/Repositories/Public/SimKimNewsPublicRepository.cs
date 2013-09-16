using System;
using System.Collections.Generic;
using System.Linq;
using DataPal.Interfaces;
using DataPal.Models;

namespace DataPal.Repositories.Public
{
    public class SimKimNewsPublicRepository : IRepository<InfoPublic>
    {
        private SitesContext dataContext;

        public SimKimNewsPublicRepository()
            :this(new SitesContext())
        { }

        public SimKimNewsPublicRepository(SitesContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(InfoPublic item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InfoPublic> GetAll()
        {
            var items = dataContext.SimKimNews;
            return items.Select(i =>
                    new InfoPublic()
                    {
                        Id = i.Id,
                        Title = i.Title,
                        Text = i.Text,
                        CreationDate = i.CreationDate,
                        UserName = i.UserProfile.UserName,
                    }
                );
        }

        public InfoPublic Get(int id)
        {
            var item = dataContext.SimKimNews.Where(n => n.Id == id).FirstOrDefault();

            if (item == null)
            {
                return null;
            }

            return new InfoPublic()
            {
                Id = item.Id,
                Title = item.Title,
                Text = item.Text,
                CreationDate = item.CreationDate,
                UserName = item.UserProfile.UserName,
            };
        }

        public void Update(int id, InfoPublic item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<InfoPublic> Find(System.Linq.Expressions.Expression<Func<InfoPublic, bool>> query)
        {
            throw new NotImplementedException();
        }
    }
}