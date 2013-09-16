using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPal.Interfaces
{
    public interface IExtendedRepository<T, U>: IRepository<T> 
        where T: class 
        where U: class
    {
        IEnumerable<U> GetAllTitles();
    }
}