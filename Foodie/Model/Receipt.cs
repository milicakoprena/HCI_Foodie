using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Model
{
    public class Receipt
    {
        public int idReceipt {  get; set; }
        public DateTime orderTime { get; set; }
        public double totalPrice { get; set; }
        public int idEmployee { get; set; }
        public List<DishItem> dishItems { get; set; } = new List<DishItem>();
        public string employee { get; set; }
    }
}
