using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DataPal.Filters;

namespace DataPal.Controllers
{
    [EnableCors]
    public class XTNAdsPhotosController : Controller
    {
        private const string dirFullSize = "/Images/XTNAdsPhotos/FullSize";
        private const string dirThumbs = "/Images/XTNAdsPhotos/Thumbs";
        private const string imagePrefix = "ID-";
        private const string imageFullSizeSufix = "_big.jpg";
        private const string imageThumbSufix = "_thumb.jpg";
        //
        // GET: /XTNAdsPhotos/
       
        public ActionResult Thumbnail(string id)
        {
            var dir = Server.MapPath(dirThumbs);

            StringBuilder sb = new StringBuilder(imagePrefix);
            sb.Append(id);
            sb.Append(imageThumbSufix);

            var path = Path.Combine(dir, sb.ToString());
            return base.File(path, "image/jpeg");
        }
       
        public ActionResult FullSize(string id)
        {
            var dir = Server.MapPath(dirFullSize);

            StringBuilder sb = new StringBuilder(imagePrefix);
            sb.Append(id);
            sb.Append(imageFullSizeSufix);

            var path = Path.Combine(dir, sb.ToString());
            return base.File(path, "image/jpeg");
        }

    }
}
