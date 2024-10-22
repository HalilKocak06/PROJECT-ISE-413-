using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BLL.DAL;

namespace BLL.Model
{
    public class CategoryModel
    {
        public Category Record { get; set; }

        public string Name => Record.Name;

        public string Description => Record.Description;

        public string user => "Halil";


    }
}
