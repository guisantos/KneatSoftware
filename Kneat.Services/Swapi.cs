using Kneat.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Kneat.Helper;
using static Kneat.Helper.CustomExceptions;
using static Kneat.Helper.HerperExtension;

namespace Kneat.Services
{
    public static class Swapi
    { 
        public static async Task<List<StarshipModel>> GetStarshipsAsync()
        {
            if (string.IsNullOrEmpty(HerperExtension.StarshipsURL) || string.IsNullOrWhiteSpace(HerperExtension.StarshipsURL))
            {
                throw new NullSpaceshipShipURLException(NullSpaceshipShipURLMsg);
            }

            List<StarshipModel> starships = new List<StarshipModel>();
            string baseUrl = HerperExtension.StarshipsURL;

            try
            {
                Console.WriteLine("Connecting to WebService and requesting the Starships...");
                Console.WriteLine("=================================================================\n");

                HttpClient httpClient = new HttpClient();

                do
                {
                    var getAsyncResponse = await httpClient.GetAsync(baseUrl);

                    if (getAsyncResponse.IsSuccessStatusCode)
                    {
                        string responseAsync = await getAsyncResponse.Content.ReadAsStringAsync();
                        var startshipHeader = JsonConvert.DeserializeObject<StartshipHeaderModel>(responseAsync);
                        if (startshipHeader != null)
                        {
                            starships.AddRange(startshipHeader.Starships.ToList());
                        }

                        baseUrl = startshipHeader.Next;
                    }

                } while (baseUrl != null);

                Console.WriteLine("Successfully requested {0} starships...", starships.Count);
                Console.WriteLine("=================================================================\n");

                return starships;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
