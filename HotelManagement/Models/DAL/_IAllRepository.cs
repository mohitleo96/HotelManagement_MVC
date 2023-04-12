using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HotelManagement.Models.DAL
{
   
    public interface _IAllRepository<T> where T : class
    {
        IEnumerable<T> GetModel();
        T GetModelById(int ModelId);
        void InsertModel(T Model);
        void UpdateModel(T Model);
        void DeleteModel(int ModelId);
        void DetailModel(T Model);
        void Save();
    }
}
