using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services
{
    public class AddressService
    {
        private IConfiguration _configuration;
        public AddressService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Address> GetAddress()
        {
            string addressURL = _configuration.GetSection("addressURL").Value;
            HttpClient client = new HttpClient();
            HttpResponseMessage reponse = await client.GetAsync(addressURL);

            Address address;
            if (reponse.IsSuccessStatusCode)
            {
                string responseData = await reponse.Content.ReadAsStringAsync();
                // http://jsonviewer.stack.hu/ viewer for JSONs
                address = JsonConvert.DeserializeObject<Address>(responseData);
            }
            else 
            {
                address = new Address();
            }

            return address;
        }
    }
}
