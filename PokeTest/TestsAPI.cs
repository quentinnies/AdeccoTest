using NUnit.Framework;

namespace PokeTest
{
    public class TestsAPI
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Todo: Test id the website is up or down
        /// Todo: Test if requests to the two APIs Work
        /// Todo: List of pokemon, 20 is nice but test with pagination
        /// Todo: Single pokemon, with it's characteristics, test if all the characteristics are affected
        /// Todo
        /// </summary>

        [Test]
        public void WebsiteIsUp()
        {
          
            Assert.Pass();
        }
        [Test]
        public void ListAPIWorks()
        {
           
            Assert.Pass();
        }
        public void CreateNewPokemon()
        {
            //supposed to fail
            Assert.Fail();
        }
        public void ModifyPokemon()
        {
            //supposed to fail
            Assert.Fail();
        }
        public void SuppressPokemon()
        {
            //supposed to fail
            Assert.Fail();
        }
        public void GetInfoFromKnownPokemon()
        {
            
            Assert.Pass();
        }
        public void Get20Pokemons()
        {

            Assert.Pass();
        }
        public void GetAllProkemons()
        {

            Assert.Pass();
        }
    }
}