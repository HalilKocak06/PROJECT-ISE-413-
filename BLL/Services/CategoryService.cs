using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using BLL.DAL;
using BLL.Model;
using BLL.Services.Bases;

namespace BLL.Services
{
    public class CategoryService : Service
    {
        private readonly Db _db;    //22 ekim -- readonly bak..

        public CategoryService(Db db): base(db)    //_db'nin üstüne quick actions yapıp generate constructor yapıyoruz.(22 ekim)
        {
        }

        public Service Create(Category record)  // Burayıda ekledik (22ekim)
        {
            _db.Category.Add(record);
            _db.SaveChanges();
            IsSuccessful = true;
            return Success("Category is created successfuly.");

        }
        
        public Service Update(Category  record)
        {
            _db.Category.Update(record);
            _db.SaveChanges();
            return Success("Category is updated successfully.");
        }

        public Service Delete(int id)
        {
            Category category = _db.Category.SingleOrDefault(c => c.id == id);
            if(category == null)
            {
                return Error("Category is not found.");
            }
            _db.Remove(category);
            _db.SaveChanges();
            return Success("Category is deleted successfully.");
        }

        public IQueryable<CategoryModel> Query()
        {
            return _db.Category.Select(c => new CategoryModel()
                {
                 Record = c
            });
        }

    }
}
