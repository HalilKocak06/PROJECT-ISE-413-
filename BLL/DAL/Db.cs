using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
    //DbContext, Entity Framework Core'un sunduğu ve veritabanı işlemlerini yöneten bir sınıftır.
    public class Db : DbContext  
    {
        public DbSet<Products> Products { get; set; } //bunlar tablolar
        public DbSet<Category> Category { get; set; } //tablolar

        public Db(DbContextOptions<Db> options) : base(options) 
        { 
        }   //buradaki base --->Dbcontext'i çağırıyor.
    }

}
