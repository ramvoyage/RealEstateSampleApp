using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class RealEstate
    {
        public int id { get; set; }

        public string area { get; set; }

        public decimal price { get; set; }

        public bool active { get; set; }
    }
}
