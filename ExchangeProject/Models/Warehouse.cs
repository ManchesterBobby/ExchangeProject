﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeProject.Models
{
    public class Warehouse
    {
        public int WarehouseID { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string PostCode { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public int LocationID { get; set; }

        public int CommodityID { get; set; }
    }
}
