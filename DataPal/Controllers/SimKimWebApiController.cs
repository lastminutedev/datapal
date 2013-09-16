using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DataPal.Filters;
using DataPal.Helpers;
using DataPal.Interfaces;
using DataPal.Models;
using DataPal.Repositories;
using DataPal.Repositories.Public;

namespace DataPal.Controllers
{
    public class SimKimWebApiController : ApiController
    {
        private IRepository<InfoPublic> repository;
       
        public SimKimWebApiController(IRepository<InfoPublic> repository)
        {
            this.repository = repository;
        }
      
        [EnableCors]
        public IEnumerable<InfoPublic> Get()
        {
            try
            {
                var simKimNews = repository.GetAll();
                var simKimNewsDecoded = simKimNews.Select(n => new InfoPublic()
                    {
                        Id = n.Id,
                        Title = n.Title,
                        Text = n.Text,
                        CreationDate = n.CreationDate,
                        UserName = n.UserName,
                    }).OrderByDescending(n => n.CreationDate);
                
                return simKimNewsDecoded;
            }
            catch 
            {
                throw new HttpRequestException("Server Error");
            }
        }

        // GET api/simkimwebapi/5
        public InfoPublic Get(int id)
        {
            try
            {
                var simKimNews = repository.Get(id);

                if (simKimNews == null)
                {
                    return new InfoPublic();
                }

                return new InfoPublic()
                        {
                            Id = simKimNews.Id,
                            Title = simKimNews.Title,
                            Text = simKimNews.Text,
                            CreationDate = simKimNews.CreationDate,
                            UserName = simKimNews.UserName,
                        }; 
            }
            catch 
            {
                throw new HttpRequestException("Server Error");
            }
        }

    }
}
