using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    public class User
    {
        //Fields
        //wkeijowewiqheiqw
        private string _name;
        private string _island;


        //Getters and Setters
        public string GetName()
        {
            return _name;
        }

        public string GetIsland()
        {
            return _island;
        }


        //Constructors
        public User(string name, string island)
        {
            _name = name;
            _island = island;
        }


        //Methods

    }
}
