using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Model
{
    public class Employee
    {
        public int idEmployee {  get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public int idRole { get; set; }
        public bool status { get; set; }
        public int theme { get; set; }
        public int language { get; set; }

    }
}
