using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataPal.Interfaces;
using Html.Helpers;

namespace DataPal.Helpers
{
    public class ControllersHelper
    {
        public static T SanitizeArticle<T>(ref T item)
        {
            IArticle article = item as IArticle;

            if (article == null)
            {
                throw new InvalidCastException("Item must have title and text.");
            }

            var title = HtmlSanitizer.sanitize(article.Title);
            var TEXT = HtmlSanitizer.sanitize(article.Text);

            return (T)article;
        }
    }
}