using bank.dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Logic
{
    public class Api
    {
        private Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient();

        public Api()
        {
            client = new Windows.Web.Http.HttpClient();
            //SET HEADERS AND CONFIG (e.g. timeout)
            //SET ENVIRONMENT live/homolog/staging
        }

        public async Task<ExtractResponse> GetExtract()
        {
            var response = await client.GetAsync(new Uri("https://s3-sa-east-1.amazonaws.com/mobile-challenge/bill/bill.json"));
            var result = await response.Content.ReadAsStringAsync();
            var status = (int)response.StatusCode;

            var billResponse = new ExtractResponse();
            billResponse.Data = JsonConvert.DeserializeObject<List<RootObject>>(result);
            billResponse.Status = status;
            return billResponse;
        }
        
    }
}
