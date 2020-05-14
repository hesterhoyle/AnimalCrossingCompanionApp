using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    //building the user
    public class User
    {
        //Fields
        private string _name;
        private string _island;
        private string _hemisphere;


        //Getters and Setters
        public string GetName()
        {
            return _name;
        }

        public string GetIsland()
        {
            return _island;
        }

        public string GetHemisphere()
        {
            return _hemisphere;
        }


        //Constructors
        public User(string name, string island, string hemisphere)
        {
            _name = name;
            _island = island;
            _hemisphere = hemisphere;
        }

    }
}
