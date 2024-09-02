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
    public class ProductRepository : Repositry<Product>, IProductRepository
    {
        private readonly ApplicationDbConteXt _db;
        public ProductRepository(ApplicationDbConteXt db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            var objForm = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if(objForm != null)
            {
                objForm.Title = obj.Title;
                objForm.ISBN = obj.ISBN;
                objForm.Price = obj.Price;
                objForm.Price50 = obj.Price50;
                objForm.ListPrice = obj.ListPrice;
                objForm.Price100 = obj.Price100;
                objForm.Description = obj.Description;
                objForm.CategoryId = obj.CategoryId;
                objForm.Author = obj.Author;
                if(objForm.ImageUrl != null)
                {
                    objForm.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
