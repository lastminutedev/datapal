using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPal.Interfaces
{
    public interface IArticle
    {
        string Title { get; set; }
        string Text { get; set; }
    }
}
