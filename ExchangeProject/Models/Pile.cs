using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeProject.Models
{
    public class Pile
    {
        public int PileID { get; set; }

        [Display(Name = "Pile Number")]
        public string PileNumber { get; set; }

        public int CommodityID { get; set; }

        [Display(Name = "Commodity Name")]
        public string CommodityName { get; set; }

        public double Weight { get; set; }

        [Display(Name = "Gross Weight")]
        public double GrossWeight { get; set; }

        public int WarehouseID { get; set; }

        [Display(Name = "Warehouse Name")]
        public string WarehouseName { get; set; }

        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

    }
}
