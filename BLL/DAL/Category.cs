using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace BLL.DAL
{
    public class Category
    {
        
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Products> Products { get; set; }  //buraya bir daha bak..

    }
}
