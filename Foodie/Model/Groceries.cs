using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Model
{
    public class Groceries
    {
        public int idGroceries {  get; set; }
        public string name {  get; set; }
        public double price { get; set; }
        public int idGroceriesUnit {  get; set; }
        public string unitName { get; set; }
    }
}
