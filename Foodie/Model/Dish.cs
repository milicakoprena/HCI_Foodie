using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Model
{
    public class Dish
    {
        public int idDish { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int idDishCategory { get; set; }
        public string dishCategoryName { get; set; }
    }
}
