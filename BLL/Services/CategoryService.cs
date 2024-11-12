using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using BLL.DAL;
using BLL.Model;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{

    public interface ICategoryService
    {
        public IQueryable<CategoryModel> Query();   //5 kasım

        public Service Create(Category model);
        public Service Update(Category model);

        public Service Delete(int id);
    }



    public class CategoryService : Service , ICategoryService
    {
        private readonly Db _db;    //22 ekim -- readonly bak..

        public CategoryService(Db db): base(db)    //_db'nin üstüne quick actions yapıp generate constructor yapıyoruz.(22 ekim)
        {
        }

        public Service Create(Category record)  // Burayıda ekledik (22ekim)
        {
            Category existingCategory =
                _db.Category.FirstOrDefault(c => c.Name.ToUpper() == record.Name.ToUpper().Trim());  //yeni eklenmek istenen kategorinin adının (record.Name) zaten mevcut olup olmadığı kontrol edilir.(5 kasım)

            if (existingCategory is not null)
                return Error("Category with the same name exists!");

            record.Name = record.Name.ToUpper();                    //5kasım
            record.Description = record.Description?.ToUpper();     //5kasım
            _db.Category.Add(record);
            _db.SaveChanges();
            IsSuccessful = true;
            return Success("Category is created successfuly.");

        }
        
        public Service Update(Category  record)
        {
            
            if(_db.Category.Any(c => c.Id != record.Id && c.Name.ToUpper() == record.Name.ToUpper().Trim()))  //(5 kasım)
                return Error("Category with the same name exists!");
        
            record.Name = record.Name.ToUpper();                    //5kasım
            record.Description = record.Description?.ToUpper();     //5kasım

            _db.Category.Update(record);
            _db.SaveChanges();
            return Success("Category is updated successfully.");
        }

        public Service Delete(int id)
        {
            Category category = _db.Category.Include(c => c.Products).SingleOrDefault(c => c.Id == id);
            if(category == null)
            {
                return Error("Category is not found.");
            }

            if (category.Products.Any())
                return Error("Category has relational products!");


            _db.Category.Remove(category);
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
