using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AdeccoTest.PokeDetails;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdeccoTest
{
    public class Pokemon
    {
        public List<Ability> abilities { get; set; }
        public int BaseXp { get; set; }
        private List<string> forms { get; set; }
        private List<Game_Indices> gameIndices { get; set; }
        public int height { get; set; }
        //todo held items
        public int id { get; set; }
        private bool isDefault { get; set; }
        //todo encounters ?
        public string name { get; set; }
        public int order { get; set; }
        private List<PokeType> pastTypes { get; set; }
        //todo check if species is an array or an object
        //todo sprites
        private List<Stat> stats { get; set; }
        private List<PokeType> types { get; set; }
        public int weight { get; set; }
        public string locationAreaEncounters { get; set; }
        internal async Task PopulateDetails(JObject current)
        {

            JObject detailPoke = null;
            HttpClient DetailedClient = new HttpClient();
            //HttpResponseMessage DetailedResponse = await DetailedClient.GetAsync((string)current.GetValue("url"));
            HttpResponseMessage DetailedResponse = await DetailedClient.GetAsync((string)current.GetValue("url"));
            if (DetailedResponse.IsSuccessStatusCode)
            {
                detailPoke = await DetailedResponse.Content.ReadAsAsync<JObject>(); //that works, has to get the product and serialize now
            }

            //I begin with simple structures because loading the others causes some problems, 
            name = (string)detailPoke.GetValue("name");
            BaseXp = (int)detailPoke.GetValue("base_experience");
            height = (int)detailPoke.GetValue("height");
            id = (int)detailPoke.GetValue("id");
            order = (int)detailPoke.GetValue("order");
            weight = (int)detailPoke.GetValue("weight");
            locationAreaEncounters = (string)detailPoke.GetValue("location_area_encounters");





            //foreach (dynamic ability in detailPoke.GetValue("abilities"))
            //{
            //    abilities.Add(new Ability("toto", (bool)detailPoke.GetValue("is_hidden"), (int)detailPoke.GetValue("slot")));
            //}
            //BaseXp = (int)detailPoke.GetValue("base_experience");
            //foreach (dynamic form in detailPoke.GetValue("forms"))
            //{
            //    forms.Add((string)detailPoke.SelectToken("form.name"));
            //}

        }
    }
}