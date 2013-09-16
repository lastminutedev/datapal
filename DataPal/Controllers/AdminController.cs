using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataPal.Filters;
using DataPal.Interfaces;
using DataPal.Models;
using DataPal.Repositories;
using Html.Helpers;
using WebMatrix.WebData;
using DataPal.Helpers;

namespace DataPal.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AdminController : Controller
    {
        private RepositoryFactory repositoryFactory;

        public AdminController()
        {
            this.repositoryFactory = new RepositoryFactory();
        }

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult SimKimNews()
        {
            IEnumerable<IdTitlePair> model = null;

            try
            {
                var collection = this.repositoryFactory.GetSimKimRepository().GetAll();
                model = collection.Select(i => new IdTitlePair() { Id = i.Id, Title = i.Title });
            }
            catch
            {
                throw new HttpRequestException("Server Error");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult AddNewSimKimNews()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewSimKimNews(SimKimNews model)
        {
            if (ModelState.IsValid)
            {
                //ControllersHelper.SanitizeArticle(ref model);

                model.CreationDate = DateTime.Now;
                model.UserId = WebSecurity.CurrentUserId;
           
                try
                {
                    this.repositoryFactory.GetSimKimRepository().Add(model);
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            
            return View();
        }
        
        [HttpGet]
        public ActionResult DetailsSimKimNews(int id)
        {
            SimKimNews model = null;
            try
            {
                model = this.repositoryFactory.GetSimKimRepository().Get(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            ViewBag.UserAdded = model.UserProfile.UserName;
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteSimKimNews(int id)
        {
            SimKimNews model = null;
            try
            {
                model = this.repositoryFactory.GetSimKimRepository().Get(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSimKimNews(XTNAd model)
        {
            try
            {
                this.repositoryFactory.GetSimKimRepository().Delete(model.Id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return RedirectToAction("SimKimNews", "Admin");
        }

        [HttpGet]
        public ActionResult EditSimKimNews(int id)
        {
            SimKimNews model = null;
            try
            {
                model = this.repositoryFactory.GetSimKimRepository().Get(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);
        }


        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditSimKimNews(SimKimNews model)
        {
            if (ModelState.IsValid)
            {
                //ControllersHelper.SanitizeArticle(ref model);

                model.LastModifiedDate = DateTime.Now;

                try
                {
                    this.repositoryFactory.GetSimKimRepository().Update(model.Id, model);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return RedirectToAction("SimKimNews", "Admin");
        }
        
        [HttpGet]
        public ActionResult XTNAds()
        {
            IEnumerable<IdTitlePair> model = null;

            try
            {
                var collection = this.repositoryFactory.GetXTNAdsRepository().GetAll();
                model = collection.Select(i => new IdTitlePair() {Id = i.Id, Title = i.Title});
            }
            catch
            {
                throw new HttpRequestException("Server Error");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewXTNAd(XTNAd model)
        {
            if (ModelState.IsValid)
            {
                //ControllersHelper.SanitizeArticle(ref model);

                model.CreationDate = DateTime.Now;
                model.UserId = WebSecurity.CurrentUserId;

                try
                {
                    this.repositoryFactory.GetXTNAdsRepository().Add(model);
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult AddNewXTNAd()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DetailsXTNAd(int id)
        {
            XTNAd model = null;
            try
            {
                model = this.repositoryFactory.GetXTNAdsRepository().Get(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            ViewBag.UserAdded = model.UserProfile.UserName;
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteXTNAd(int id)
        {
            XTNAd model = null;
            try
            {
                model = this.repositoryFactory.GetXTNAdsRepository().Get(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteXTNAd(XTNAd model)
        {
            try
            {
                this.repositoryFactory.GetXTNAdsRepository().Delete(model.Id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return RedirectToAction("XTNAds", "Admin");
        }

        [HttpGet]
        public ActionResult EditXTNAd(int id)
        {
            XTNAd model = null;
            try
            {
                model = this.repositoryFactory.GetXTNAdsRepository().Get(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);
        }


        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditXTNAd(XTNAd model)
        {
            if (ModelState.IsValid)
            {
                //ControllersHelper.SanitizeArticle(ref model);

                model.LastModifiedDate = DateTime.Now;

                try
                {
                    this.repositoryFactory.GetXTNAdsRepository().Update(model.Id, model);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return RedirectToAction("XTNAds", "Admin");
        }
    }
}
