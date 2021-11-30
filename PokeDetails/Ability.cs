using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdeccoTest.PokeDetails
{
    public class Ability
    {
        private string _name;
        private bool _isHidden;
        private int _slot;

        public Ability(string name, bool isHidden, int slot)
        {
            _name = name;
            _isHidden = isHidden;
            _slot = slot;
        }
    }

}
