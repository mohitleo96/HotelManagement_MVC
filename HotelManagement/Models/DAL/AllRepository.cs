using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HotelManagement.Models.DAL
{
   
    public class AllRepository<T> : _IAllRepository<T> where T : class 
    {
        private HotelManagementDBEntities2 _context = null;
        private IDbSet<T> _dbEntity = null;

        public AllRepository()
            {
            this._context= new HotelManagementDBEntities2();
            _dbEntity= _context.Set<T>();
            }
        public void DeleteModel(int ModelId)
        {
            T Model = _dbEntity.Find(ModelId);
            _dbEntity.Remove(Model);
        }

        public void DetailModel(T Model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetModel()
        {
           return _dbEntity.ToList();
        }

        public T GetModelById(int ModelId)
        {
            return _dbEntity.Find(ModelId);
        }

        public void InsertModel(T Model)
        {
            _dbEntity.Add(Model);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateModel(T Model)
        {
           _context.Entry(Model).State=System.Data.Entity.EntityState.Modified;
        }
    }
}