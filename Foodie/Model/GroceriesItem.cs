using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Model
{
    public class GroceriesItem
    {
        public int idGroceriesItem {  get; set; }
        public byte amount { get; set; }
        public double totalPrice { get; set; }
        public int idGroceries { get; set; }
        public int idOrder { get; set; }
        public string groceriesName { get; set; }
    }
}
