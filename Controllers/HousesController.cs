using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;


        public HousesController(IConfiguration configuration,  IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet("GetById/{id}")]
        public HousesModel[] GetById(int id)
        {
            string query = @"select * from houses where id = @id";
            DataTable table = new();
            string sqlDataSource = _configuration.GetConnectionString("WebApiDatabase");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myConn = new NpgsqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myConn.Close();
                }
            }

            var retList = new List<HousesModel>();
            foreach (DataRow dataRow in table.Select())
            {
                retList.Add((new HousesModel()
                {
                    Price = (int)dataRow["Price"],
                    PublicationDate = (DateTime)dataRow["PublicationDate"],
                    Geo_Lat = (double)dataRow["geo_lat"],
                    Geo_Lon = (double)dataRow["geo_lon"],
                    Region = (int)dataRow["region"],
                    Building_Type = (int)dataRow["building_type"],
                    FloorNum = (int)dataRow["FloorNum"],
                    TotalFloor = (int)dataRow["TotalFloor"],
                    Rooms = (int)dataRow["Rooms"],
                    Area = (double)dataRow["Area"],
                    Object_Type = (int)dataRow["Object_Type"],
                    Id = (int)dataRow["Id"],
                    status = (int)dataRow["status"],
                    Photopath = (byte[])dataRow["Photopath"]
                }));
            }

            return retList.ToArray();
        }
        
        [HttpGet]
        public HousesModel[] Get()
        {
            string query = @"select * from houses order by id desc limit 50";
            DataTable table = new();
            string sqlDataSource = _configuration.GetConnectionString("WebApiDatabase");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myConn = new NpgsqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myConn.Close();
                }
            }


            var retList = new List<HousesModel>();
            foreach (DataRow dataRow in table.Select())
            {
                retList.Add((new HousesModel()
                {
                    Price = (int)dataRow["Price"],
                    PublicationDate = (DateTime)dataRow["PublicationDate"],
                    Geo_Lat= (double)dataRow["geo_lat"],
                    Geo_Lon= (double)dataRow["geo_lon"],
                    Region = (int)dataRow["region"],
                    Building_Type = (int)dataRow["building_type"],
                    FloorNum = (int)dataRow["FloorNum"],
                    TotalFloor = (int)dataRow["TotalFloor"],
                    Rooms = (int)dataRow["Rooms"],
                    Area = (double)dataRow["Area"],
                    Object_Type = (int)dataRow["Object_Type"],
                    Id = (int)dataRow["Id"],
                    status = (int)dataRow["status"],
                    Photopath = (byte[])dataRow["Photopath"]
                }));
            }

            
            return retList.ToArray();
        }

        [HttpPost("Post")]
        public JsonResult Post(HousesModel house)
        {
            string query = @"insert into houses(price, publicationDate, geo_lat, geo_lon, region, building_type, floorNum, totalFloor, rooms, area, object_type, status, photopath)
                            values (@price, @publicationDate, @geo_lat, @geo_lon, @region, @building_type, @floorNum, @totalFloor, @rooms, @area, @object_type, @status, @photopath)";
            DataTable table = new();
            string sqlDataSource = _configuration.GetConnectionString("WebApiDatabase");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myConn = new NpgsqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@price", house.Price);
                    myCommand.Parameters.AddWithValue("@publicationDate", house.PublicationDate);
                    myCommand.Parameters.AddWithValue("@geo_lat", house.Geo_Lat);
                    myCommand.Parameters.AddWithValue("@geo_lon", house.Geo_Lon);
                    myCommand.Parameters.AddWithValue("@region", house.Region);
                    myCommand.Parameters.AddWithValue("@building_type", house.Building_Type);
                    myCommand.Parameters.AddWithValue("@floorNum", house.FloorNum);
                    myCommand.Parameters.AddWithValue("@totalFloor", house.TotalFloor);
                    myCommand.Parameters.AddWithValue("@rooms", house.Rooms);
                    myCommand.Parameters.AddWithValue("@area", house.Area);
                    myCommand.Parameters.AddWithValue("@object_type", house.Object_Type);
                    myCommand.Parameters.AddWithValue("@status", house.status);
                    myCommand.Parameters.AddWithValue("@photopath", house.Photopath);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }
        
        [HttpPut("Put")]
        public JsonResult Put(HousesModel house)
        {
            string query = @"update houses
                                set price=@price, publicationDate=@publicationDate, geo_lat=@geo_lat, geo_lon=@geo_lon, region=@region,
                                    building_type=@building_type, floorNum=@floorNum, totalFloor=@totalFloor, rooms=@rooms, area=@area, object_type=@object_type, photopath=@photopath
                                where id=@id
                            ";

            DataTable table = new();
            string sqlDataSource = _configuration.GetConnectionString("WebApiDatabase");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myConn = new NpgsqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@price", house.Price);
                    myCommand.Parameters.AddWithValue("@publicationDate", house.PublicationDate);
                    myCommand.Parameters.AddWithValue("@geo_lat", house.Geo_Lat);
                    myCommand.Parameters.AddWithValue("@geo_lon", house.Geo_Lon);
                    myCommand.Parameters.AddWithValue("@region", house.Region);
                    myCommand.Parameters.AddWithValue("@building_type", house.Building_Type);
                    myCommand.Parameters.AddWithValue("@floorNum", house.FloorNum);
                    myCommand.Parameters.AddWithValue("@totalFloor", house.TotalFloor);
                    myCommand.Parameters.AddWithValue("@rooms", house.Rooms);
                    myCommand.Parameters.AddWithValue("@area", house.Area);
                    myCommand.Parameters.AddWithValue("@object_type", house.Object_Type);
                    myCommand.Parameters.AddWithValue("@id", house.Id);
                    myCommand.Parameters.AddWithValue("@photopath", house.Photopath);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }
        
        [HttpDelete("Delete")]
        public JsonResult Delete(int id)
        {
            string query = @"update houses set status=0 where id=@id ";
            DataTable table = new();
            string sqlDataSource = _configuration.GetConnectionString("WebApiDatabase");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myConn = new NpgsqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Disabled Successfully");
        }
    }
}
