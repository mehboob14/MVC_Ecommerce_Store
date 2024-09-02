using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.dataAccess.Repository.IRepository;
using Web.Models;

namespace Web.dataAccess.Repositry.IRepositry
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Add(Category category);
        void Update(Category category);
       
        
    }
}
