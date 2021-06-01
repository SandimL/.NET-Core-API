using Microsoft.AspNetCore.Mvc;
using Hahn.ApplicatonProcess.February2021.Data.UnityOfWork;
using Hahn.ApplicatonProcess.February2021.Domain.Models.Assets;
using Hahn.ApplicatonProcess.February2021.Domain.Models.Country;
using System.Threading.Tasks;
using System.Threading;
using Hahn.ApplicatonProcess.February2021.Data.Service.CountryService;
using Hahn.ApplicatonProcess.February2021.Web.Response;
using Serilog;
using Microsoft.Extensions.Configuration;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hahn.ApplicatonProcess.February2021.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private IUnityOfWork _unityOfWork;
        private ICountryService _countryService;

        public AssetsController(IUnityOfWork unityOfWork, ICountryService countryService)
        {
            _unityOfWork = unityOfWork;
            _countryService = countryService;
        }


        // GET api/<AssetsController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            Log.Information($"API interaction on GET, Asset id: {id}");
            Asset asset = await _unityOfWork.Assets.Get(id);

            if(asset != null)
            {
                return new BasicResponse(200, asset).Json();
            }
            else
            {
                return new BasicResponse(400, "Asset not found").Json();
            }
        }

        // POST api/<AssetsController>
        [HttpPost]
        public JsonResult Post([FromBody] Asset newAsset)
        {
            Log.Information($"API interaction on POST, Asset received: {newAsset}");
            _unityOfWork.Assets.Add(newAsset);
            _unityOfWork.Commit();

            return new BasicResponse(201, $"Asset created! You can find it here: {this.Request.Scheme}://{this.Request.Host}/api/Assets/{newAsset.ID}")
                .Json();
        }

        // PUT api/<AssetsController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Asset updateAsset)
        {
            Log.Information($"API interaction on PUT, Asset received: {updateAsset}");
            _unityOfWork.Assets.Update(updateAsset);
            _unityOfWork.Commit();

            return new BasicResponse(200, "Asset updated").Json();
        }

        // DELETE api/<AssetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Log.Information($"API interaction on PUT, Asset id: {id}");
            _unityOfWork.Assets.Delete(id);
            _unityOfWork.Commit();
        }

        //TODO
        //Add rule validator to asset with this 
        private async Task<bool> isValidCountry(string country, CancellationToken arg2)
        {
            CountryExists countryExists = await _countryService.searchByName(country);
            return countryExists.httpStatusCode == 200;
        }
    }
}
