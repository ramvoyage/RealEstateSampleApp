using Data;
using RealEstateApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateApp.Controllers
{
  public class BaseController<T> : Controller, IBaseRepository<T>, IDisposable where T : class
  {

    private readonly RealEstateAppContext _context;
    public BaseController()
    {

    }
    public BaseController(RealEstateAppContext context)
    {
      _context = context;
    }
    public T Add(T entity)
    {
      _context.Entry<T>(entity).State = EntityState.Added;
      _context.SaveChanges();

      return entity;
    }

    public IQueryable<T> GetAll()
    {
      return _context.Set<T>();
    }

    public T GetById(int Id)
    {
      return _context.Set<T>().Find(Id);
    }

    public T Update(T entity)
    {
      _context.Entry<T>(entity).State = EntityState.Modified;
      _context.SaveChanges();

      return entity;

    }

    private bool disposed = false;

    protected override void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing && _context != null)
        {
          _context.Dispose();
        }
      }
      this.disposed = true;
    }

    public new void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }
  }
}
