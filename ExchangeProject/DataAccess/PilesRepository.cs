using Dapper;
using ExchangeProject.Models;
using ExchangeProject.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeProject.DataAccess
{
    public class PilesRepository : IPiles
    {

        public PilesRepository()
        {
        }

        public List<Commodity> GetCommodity()
        {
            string dbConnection = @"data source=localhost\SQLEXPRESS;initial catalog=HenryBathTest;integrated security=True;";

            List<Commodity> commodities = new List<Commodity>();

            using var con = new SqlConnection(dbConnection);

            try
            {
                con.Open();

                commodities = con.Query<Commodity>("[dbo].[GetCommodities]", commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return commodities;


        }

        public List<Location> GetLocations()
        {
            string dbConnection = @"data source=localhost\SQLEXPRESS;initial catalog=HenryBathTest;integrated security=True;";

            List<Location> locations = new List<Location>();

            using var con = new SqlConnection(dbConnection);

            try
            {
                con.Open();

                locations = con.Query<Location>("[dbo].[GetLocations]", commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return locations;


        }

        public List<Pile> GetPiles(string pileNumber, int commodity, int location, int warehouse)
        {
            string dbConnection = @"data source=localhost\SQLEXPRESS;initial catalog=HenryBathTest;integrated security=True;";

            List<Pile> piles = new List<Pile>();

            using var con = new SqlConnection(dbConnection);

            try
            {
                con.Open();

                DynamicParameters parameters = new DynamicParameters();
                if (!string.IsNullOrWhiteSpace(pileNumber))
                {
                    parameters.Add("@pileNumber", pileNumber);
                }

                if (commodity > 0)
                {
                    parameters.Add("@commodityID", commodity);
                }

                if (location > 0)
                {
                    parameters.Add("@locationID", location);
                }

                if (warehouse > 0)
                {
                    parameters.Add("@warehouseID", warehouse);
                }

                piles = con.Query<Pile>("[dbo].[GetPilesByParameters]",
                    parameters, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return piles;

        }

        public List<Pile> GetPilesByCommodity(string commodityCode)
        {
            string dbConnection = @"data source=localhost\SQLEXPRESS;initial catalog=HenryBathTest;integrated security=True;";

            List<Pile> piles = new List<Pile>();

            using var con = new SqlConnection(dbConnection);

            try
            {
                con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@commodityCode", commodityCode);

                piles = con.Query<Pile>("[dbo].[GetPilesByCommodity]",
                    parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return piles;

        }

        public List<Pile> GetPilesByLocation(string locationName)
        {
            string dbConnection = @"data source=localhost\SQLEXPRESS;initial catalog=HenryBathTest;integrated security=True;";

            List<Pile> piles = new List<Pile>();

            using var con = new SqlConnection(dbConnection);

            try
            {
                con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@locationName", locationName);

                piles = con.Query<Pile>("[dbo].[GetPilesByLocation]",
                    parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return piles;

        }

        public List<Pile> GetPilesByWarehouse(string warehouseName)
        {
            string dbConnection = @"data source=localhost\SQLEXPRESS;initial catalog=HenryBathTest;integrated security=True;";

            List<Pile> piles = new List<Pile>();

            using var con = new SqlConnection(dbConnection);

            try
            {
                con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@warehouseName", warehouseName);

                piles = con.Query<Pile>("[dbo].[GetPilesByWarehouse]",
                    parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return piles;

        }

        public List<Warehouse> GetWarehousesByCommodity(int commodityID)
        {
            string dbConnection = @"data source=localhost\SQLEXPRESS;initial catalog=HenryBathTest;integrated security=True;";

            List<Warehouse> warehouses = new List<Warehouse>();

            using var con = new SqlConnection(dbConnection);

            try
            {
                con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@commodityID", commodityID);

                warehouses = con.Query<Warehouse>("[dbo].[GetWarehousesByCommodity]",
                    parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return warehouses;


        }

        public List<Warehouse> GetWarehousesByLocation(int locationID)
        {
            string dbConnection = @"data source=localhost\SQLEXPRESS;initial catalog=HenryBathTest;integrated security=True;";

            List<Warehouse> warehouses = new List<Warehouse>();

            using var con = new SqlConnection(dbConnection);

            try
            {
                con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@locationID", locationID);

                warehouses = con.Query<Warehouse>("[dbo].[GetWarehousesByLocation]",
                    parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return warehouses;


        }
    }
}
