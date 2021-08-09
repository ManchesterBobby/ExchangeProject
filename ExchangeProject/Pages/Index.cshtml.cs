using ExchangeProject.Models;
using ExchangeProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeProject.Pages
{
    public class IndexModel : PageModel
    {
        private IPiles _pilesRepository;

        public IndexModel(IPiles pilesRepository)
        {
            _pilesRepository = pilesRepository;
        }

        [BindProperty]
        public List<Models.Pile> PilesList { get; set; }

        public SelectList Commodities { get; set; }
        public List<Commodity> CommoditiesList { get; set; }

        public SelectList Locations { get; set; }
        public List<Location> LocationsList { get; set; }

        public SelectList Warehouses { get; set; }
        public List<Warehouse> WarehousesList { get; set; }

        [BindProperty]
        public string SelectedPileNumber { get; set; }

        [BindProperty]
        public int SelectedLocation { get; set; }

        [BindProperty]
        public int SelectedCommodity { get; set; }

        [BindProperty]
        public int SelectedWarehouse { get; set; }

        public void OnGet()
        {
            PilesList = new List<Pile>();

            PopulateSelectLists();

        }

        public void OnPost()
        {
            PilesList = _pilesRepository.GetPiles(SelectedPileNumber, SelectedCommodity, SelectedLocation, SelectedWarehouse);
            PopulateSelectLists();
        }

        public JsonResult OnGetFilterWarehouseByLocation(int location)
        {

            WarehousesList = _pilesRepository.GetWarehousesByLocation(location);
            Warehouses = new SelectList(WarehousesList, nameof(Warehouse.WarehouseID), nameof(Warehouse.Name));

            PopulateSelectLists();
            return new JsonResult(WarehousesList);
        }

        public JsonResult OnGetFilterWarehouseByCommodity(int commodity)
        {
            WarehousesList = _pilesRepository.GetWarehousesByCommodity(commodity);
            Warehouses = new SelectList(WarehousesList, nameof(Warehouse.WarehouseID), nameof(Warehouse.Name));

            PopulateSelectLists();
            return new JsonResult(WarehousesList);

        }

        private void PopulateSelectLists()
        {
            LocationsList = _pilesRepository.GetLocations();
            Locations = new SelectList(LocationsList, nameof(Location.LocationID), nameof(Location.Name));

            CommoditiesList = _pilesRepository.GetCommodity();
            Commodities = new SelectList(CommoditiesList, nameof(Commodity.CommodityID), nameof(Commodity.Name));

        }
    }
}
