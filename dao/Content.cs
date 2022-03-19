using InsaatAPINet.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;


namespace InsaatAPINet.dao
{
    public class Content
    {

        InsaatContext context = new InsaatContext();

        public object DataTime { get; private set; }

        public string GetCityList()
        {
            var cities = context.Cities.ToList();

            var resultJson = JsonConvert.SerializeObject(new [] 
            {
                new 
            {
                Result ="İşlem Başarılı!.",
                Message= "",
                CityTable = cities,
            }
            });
            return resultJson;
        }

        public async Task<string> PostCity([FromBody]City req)
        {
            var cities = new City
            {
                CityName = req.CityName,

            };
            context.Cities.Add(cities);
            await context.SaveChangesAsync();
            var resultJson = JsonConvert.SerializeObject(new
            {
                Result = "İşlem Başarılı!",
            });
            return resultJson;
        }
        public async Task<string>PutCity([FromBody] City req)
        {
            var city = context.Cities.FirstOrDefault(c=> c.CityID == req.CityID);
            city.CityName = req.CityName;
            city.UpdateDate = DateTime.Now;
            await context.SaveChangesAsync();
            var resultJson = JsonConvert.SerializeObject(new
            {
                Result = "İşlem Başarılı",
            });
            return resultJson;
        }

        public async Task<string> DeleteCity([FromBody] City req)
        {
            var city = context.Cities.FirstOrDefault(c => c.CityID == req.CityID);
            context.Cities.Remove(city);
            await context.SaveChangesAsync();
            var resultJson = JsonConvert.SerializeObject(new
            {
                Result = "İşlem Başarılı",
            });
            return resultJson;
        }

        public async Task<string>GetFlatTypeList()
        {
            var con = new SqlConnection(@"Server=OKANCAN; Database=Insaat;User ID=sa;Password=1;");
            con.Open();
            var query = "SELECT FlatTypeID,FlatTypeName FROM FlatType";
            var cmd = new SqlCommand(query, con);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            var dt = new DataTable();
            dt.Load(reader);
            List<DataRow> result = dt.AsEnumerable().ToList();
            reader.Close();
            con.Close();
            var resultJson = JsonConvert.SerializeObject(new[]
            {
                                (
                    Result : " İşlem Başarılı!",
                    FlatTypeTable : result.CopyToDataTable()

                )
            }); 
            return resultJson;

        }
       

    }
}
