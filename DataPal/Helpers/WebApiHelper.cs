using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataPal.Models;

namespace DataPal.Helpers
{
    public class WebApiHelper
    {
        public static Func<InfoPublic, InfoPublic> PublicHTMLDecoder = delegate(InfoPublic item)
        {
            return new InfoPublic()
            {
                Id = item.Id,
                Title = HttpUtility.HtmlDecode(item.Title),
                Text = HttpUtility.HtmlDecode(item.Text),
                CreationDate = item.CreationDate,
                UserName = item.UserName,
            };
        };

        public static Func<InfoTitlesPublic, InfoTitlesPublic> PublicHTMLTitlesDecoder = delegate(InfoTitlesPublic item)
        {
            return new InfoTitlesPublic()
            {
                Id = item.Id,
                Title = HttpUtility.HtmlDecode(item.Title),
                CreationDate = item.CreationDate,
                UserName = item.UserName,
            };
        };

        public static Func<InfoPublic, string> PublicHTMLTextDecoder = delegate(InfoPublic item)
        {
            return HttpUtility.HtmlDecode(item.Text);
        };
    }
}