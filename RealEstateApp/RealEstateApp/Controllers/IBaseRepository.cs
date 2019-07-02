using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateApp.Controllers
{
  public interface IBaseRepository<T> where T : class
  {
    //get all data
    IQueryable<T> GetAll();
    //get specific data
    T GetById(int Id);
    //Add entity
    T Add(T entity);
    //Update Entity
    T Update(T entity);

  }
}
