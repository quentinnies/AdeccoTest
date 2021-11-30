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
            // connection to get the 20 pokemons and the url to get more details about them
            HttpClient client = new HttpClient();
            JObject BasePoke = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                BasePoke = await response.Content.ReadAsAsync<JObject>();
            }


            // we create a list of pokemons and loop through the response we got from PokeAPI
            List<Pokemon> pokeResult = new List<Pokemon>();
            if (BasePoke != null)
                foreach (JObject current in BasePoke["results"])
                {
                    //we now have the list of pokemons with their url
                    Pokemon poke = new Pokemon();
                    //we wait for the populate operation to be done before adding to the Lise, to avoid corrupted data
                    Task tsk = poke.PopulateDetails(current);
                    tsk.Wait();
                    pokeResult.Add(poke);
                }
            else
            {
                return null;
            }
            return pokeResult;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            //Theres most likely a problem with the serialization of multi-nested elements since Abilities and forms are not sent
            var result = await GetPokemonAsync("Https://pokeapi.co/api/v2/pokemon"); // the url be in config and not hardcoded
            if(result != null)
                return new JsonResult(result);
            else
                return new JsonResult("There was an error accessing the API");
        }
    }

}

