using InsaatAPINet.dao;
using InsaatAPINet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsaatAPINet.Controllers
{
    [Route("/")]
    
    public class ContentController : ControllerBase
    {
        Content content = new Content();

        [HttpGet]
        [Route("getcitylist")]
        public string GetCityList()
            {
                return content.GetCityList();
            }

            [HttpPost]
            [Route("PostCity")]
            [Consumes("application/json")]
            public async Task<string> PostCity([FromBody]City req)
             {
                return await content.PostCity(req);  
             }

        [HttpPut]
        [Route("PutCity")]
        [Consumes("application/json")]
        public async Task<string> PutCity([FromBody] City req)
        {
            return await content.PutCity(req);
        }

        [HttpDelete]
        [Route("DeleteCity")]
        [Consumes("application/json")]
        public async Task<string> DeleteCity([FromBody] City req)
        {
            return await content.DeleteCity(req);
        }
        // Get FlatTypeList
        [HttpGet]
        [Route("GetFlatTypeList")]
        public async Task< string> GetFlatTypeList()
        {
            return await content.GetFlatTypeList();
        }







    }
}
