using DMB.IdentityMessage.DataAccessLayer.Abstract;
using DMB.IdentityMessage.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMB.IdentityMessage.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {

        DMBContext context = new DMBContext();


        public void Delete(int id)
        {
            var value = context.Set<T>().Find(id);
            context.Set<T>().Remove(value);
            context.SaveChanges();
        }
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public List<T> GetListAll()
        {
            return context.Set<T>().ToList();
        }
        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
