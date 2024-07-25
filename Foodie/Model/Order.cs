using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Model
{
    public class Order
    {
        public int idOrder {  get; set; }
        public DateTime orderTime { get; set; }
        public double totalPrice { get; set; }
        public int idEmployee {  get; set; }
        public string employee {  get; set; }
        public List<GroceriesItem> groceriesItems { get; set; }
    }
}
