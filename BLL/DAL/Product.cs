using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable  // Buna da bir bak...

namespace BLL.DAL
{
    public class Product
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public decimal  UnitPrice { get; set; }

        public DateTime? ExpirationData { get; set;}
        
        public int? StockAmount { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }   //Sanırım bu class Category olan...
        
        
    }

}
