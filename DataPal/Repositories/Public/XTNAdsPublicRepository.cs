using System;
using System.Collections.Generic;
using System.Linq;
using DataPal.Interfaces;
using DataPal.Models;

namespace DataPal.Repositories.Public
{
    public class XTNAdsPublicRepository : IExtendedRepository<InfoPublic, InfoTitlesPublic>
    {
        private static IEnumerable<InfoImagesPublic> imagesInfo;

        private SitesContext dataContext;
        protected SitesContext DataContext
        {
            get { return dataContext; }
            private set { dataContext = value; }
        }

        public static IEnumerable<InfoImagesPublic> ImagesInfo
        {
            get
            {
                if (imagesInfo == null)
                {
                    imagesInfo = new List<InfoImagesPublic>()
                    {
                        new InfoImagesPublic() {Id = 0, Height = 136, Width = 205, FullSizeLink = "XTNAdsPhotos/FullSize", ThumbnailLink = "XTNAdsPhotos/Thumbnail" },
                        new InfoImagesPublic() {Id = 1, Height = 136, Width = 205, FullSizeLink = "XTNAdsPhotos/FullSize", ThumbnailLink = "XTNAdsPhotos/Thumbnail"},
                        new InfoImagesPublic() {Id = 2, Height = 136, Width = 205, FullSizeLink = "XTNAdsPhotos/FullSize", ThumbnailLink = "XTNAdsPhotos/Thumbnail"},
                    };
                }
                return imagesInfo;
            }
        }

        public XTNAdsPublicRepository()
            :this(new SitesContext())
        { }

        public XTNAdsPublicRepository(SitesContext dataContext)
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
            var items = dataContext.XTNAds;
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
            var item = dataContext.XTNAds.Where(n => n.Id == id).FirstOrDefault();

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

        public IEnumerable<InfoTitlesPublic> GetAllTitles()
        {
            var items = this.DataContext.XTNAds;
            return items.Select(i =>
                    new InfoTitlesPublic()
                    {
                        Id = i.Id,
                        Title = i.Title,
                        CreationDate = i.CreationDate,
                        UserName = i.UserProfile.UserName,
                    }
                );
        }

        public IQueryable<InfoPublic> Find(System.Linq.Expressions.Expression<Func<InfoPublic, bool>> query)
        {
            throw new NotImplementedException();
        }
    }
}