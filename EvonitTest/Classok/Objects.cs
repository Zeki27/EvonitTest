using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvonitTest.Classok
{
    class Objects
    {
        public string Id { get; init; }
        public string Nev { get; set; }
        public Objects(string id, string nev)
        {
            Id = id;
            Nev = nev;
        }
    }
}
