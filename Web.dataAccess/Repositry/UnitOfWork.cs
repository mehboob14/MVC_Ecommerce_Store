using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.dataAccess.Data;
using Web.dataAccess.Repositry.IRepositry;
using Web.Models;

namespace Web.dataAccess.Repositry
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbConteXt _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
       

        public UnitOfWork(ApplicationDbConteXt db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }
       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
