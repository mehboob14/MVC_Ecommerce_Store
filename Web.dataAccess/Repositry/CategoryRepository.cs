using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.dataAccess.Data;
using Web.dataAccess.Repository.IRepository;
using Web.dataAccess.Repositry.IRepositry;
using Web.Models;

namespace Web.dataAccess.Repositry
{
    public class CategoryRepository : Repositry<Category>, ICategoryRepository
    {
        private readonly ApplicationDbConteXt _db;
        public CategoryRepository(ApplicationDbConteXt db) : base(db)
        {
            _db = db;
        }
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }

      /*  public void Save()
        {
            _db.SaveChanges();
        }*/

    }
}
