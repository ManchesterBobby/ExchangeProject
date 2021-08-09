using ExchangeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeProject.Repositories
{
    public interface IPiles
    {
        List<Pile> GetPiles(string pileNumber, int commodity, int location, int warehouse);

        List<Pile> GetPilesByCommodity(string commodityCode);

        List<Pile> GetPilesByLocation(string locationName);

        List<Pile> GetPilesByWarehouse(string warehouseName);

        List<Location> GetLocations();

        List<Warehouse> GetWarehousesByCommodity(int commodityID);

        List<Warehouse> GetWarehousesByLocation(int locationID);

        List<Commodity> GetCommodity();

        
    }
}
