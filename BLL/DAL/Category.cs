using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace BLL.DAL
{
    public class Category
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public List<Product[]> Products { get; set; }  //buraya bir daha bak..

    }
}
