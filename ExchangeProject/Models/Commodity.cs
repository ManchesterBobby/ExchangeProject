using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeProject.Models
{
    public class Commodity
    {
        public int CommodityID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public double WeightRange { get; set; }

        public int IsActive { get; set; }

        public string Exchange { get; set; }
    }
}
