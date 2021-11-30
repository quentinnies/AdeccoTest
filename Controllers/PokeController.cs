using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdeccoTest
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeController : ControllerBase
    {
        public async Task<List<Pokemon>> GetPokemonAsync(string path)
        {
            HttpClient client = new HttpClient();

            JObject BasePoke = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                BasePoke = await response.Content.ReadAsAsync<JObject>(); //that works, has to get the product and serialize now
            }

            List<Pokemon> pokeResult = new List<Pokemon>();
            if (BasePoke != null)
                foreach (JObject current in BasePoke["results"])
                {
                    //we now have the list of pokemons with their url
                    Pokemon poke = new Pokemon();

                    Task tsk = poke.PopulateDetails(current);
                    tsk.Wait();


                    pokeResult.Add(poke);
                }

            return pokeResult;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var result = await GetPokemonAsync("Https://pokeapi.co/api/v2/pokemon");
            return new JsonResult(result);
        }
    }

}

