using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yoxlama.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category(int _id)
        {
            this.CategoryId= _id;
        }
    }
}