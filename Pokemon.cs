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
        // I had to set them to public for the JsonSerializer to send them
        public List<Ability> Abilities { get; set; }
        public int BaseXp { get; set; }
        private List<string> Forms { get; set; }
        private List<Game_Indices> GameIndices { get; set; }
        public int height { get; set; }
        //todo held items
        public int id { get; set; }
        private bool isDefault { get; set; }
        //todo encounters ?
        public string Name { get; set; }
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
            // need to instanciate the lists before affecting values to them
            Abilities = new List<Ability>();
            Forms = new List<string>();

            //getting detailed info from each pokemon using the url stored in the object sent by the list API
            JObject detailPoke = null;
            HttpClient DetailedClient = new HttpClient();
            HttpResponseMessage DetailedResponse = await DetailedClient.GetAsync((string)current.GetValue("url"));
            if (DetailedResponse.IsSuccessStatusCode)
            {
                detailPoke = await DetailedResponse.Content.ReadAsAsync<JObject>(); 
            }


            if (detailPoke != null)
            {
                //I begin with simple structures because loading the others causes some problems, 
                Name = (string)detailPoke.GetValue("name");
                BaseXp = (int)detailPoke.GetValue("base_experience");
                height = (int)detailPoke.GetValue("height");
                id = (int)detailPoke.GetValue("id");
                order = (int)detailPoke.GetValue("order");
                weight = (int)detailPoke.GetValue("weight");
                locationAreaEncounters = (string)detailPoke.GetValue("location_area_encounters");

                //adding the abilities and their nested values
                foreach (dynamic ability in detailPoke.GetValue("abilities"))
                {
                    Abilities.Add(new Ability((string)ability.SelectToken("ability.name"), (bool)ability.GetValue("is_hidden"), (int)ability.GetValue("slot")));
                }
                //adding the forms in nested values too, they're loaded in the object but not sent through the API
                foreach (dynamic form in detailPoke.GetValue("forms"))
                {
                    Forms.Add((string)form.SelectToken("name"));
                }
            }
            else
            {
                //return an error during the access to the data
            }

           

        }
    }
}