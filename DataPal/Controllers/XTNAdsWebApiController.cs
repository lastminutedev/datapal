using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataPal.Filters;
using DataPal.Helpers;
using DataPal.Interfaces;
using DataPal.Models;
using DataPal.Repositories;
using DataPal.Repositories.Public;

namespace DataPal.Controllers
{
    public class XTNAdsWebApiController : ApiController
    {
        private IExtendedRepository<InfoPublic, InfoTitlesPublic> repository;

        public XTNAdsWebApiController(IExtendedRepository<InfoPublic, InfoTitlesPublic> repository)
        {
            this.repository = repository;
        }

        // GET api/<controller>
        public IEnumerable<InfoPublic> Get()
        {
            try
            {
                var xtnAds = repository.GetAll();
                var xtnAdsDecoded = xtnAds.Select(n => new InfoPublic()
                    {
                        Id = n.Id,
                        Title = n.Title,
                        Text = n.Text,
                        CreationDate = n.CreationDate,
                        UserName = n.UserName,
                    }).OrderByDescending(n => n.CreationDate);

                return xtnAdsDecoded;
            }
            catch
            {
                throw new HttpRequestException("Server Error");
            }
        }

        [EnableCors]
        public string Get(int id)
        {
            try
            {
                var xtnAd = repository.Get(id);

                if (xtnAd == null)
                {
                    return null;
                }

                var adText = xtnAd.Text;

                return adText;
            }
            catch
            {
                throw new HttpRequestException("Server Error");
            }
        }

        [EnableCors]
        public IEnumerable<InfoTitlesPublic> GetTitlesOnly()
        {
            try
            {
                var xtnAdsTitles = repository.GetAllTitles();
                var xtnAdsTitlesDecoded = xtnAdsTitles.Select(n => new InfoTitlesPublic()
                    {
                        Id = n.Id,
                        Title = n.Title,
                        CreationDate = n.CreationDate,
                        UserName = n.UserName,
                    }).OrderByDescending(n => n.CreationDate);

                return xtnAdsTitlesDecoded;
            }
            catch
            {
                throw new HttpRequestException("Server Error");
            }
        }

        [EnableCors]
        public IEnumerable<InfoImagesPublic> GetImagesInfo()
        {
            try
            {
                var xtnAdsImagesInfo = XTNAdsPublicRepository.ImagesInfo;
                return xtnAdsImagesInfo;
            }
            catch
            {
                throw new HttpRequestException("Server Error");
            }
        }
    }
}