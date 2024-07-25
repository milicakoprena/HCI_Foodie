using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Model
{
    public class DishItem
    {
        public byte amount {  get; set; }
        public double totalPrice { get; set; }
        public int idDish {  get; set; }
        public string dishName { get; set; }

    }
}
