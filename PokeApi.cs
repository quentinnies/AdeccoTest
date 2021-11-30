using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AdeccoTest
{
    public class PokeApi
    {
        //base url, we'll need to add the pokemon number for the detail
        public string url = "Https://pokeapi.co/api/v2/pokemon";
        private List<Pokemon> response;
    }
}
