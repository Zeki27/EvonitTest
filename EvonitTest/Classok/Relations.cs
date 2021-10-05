using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvonitTest.Classok
{
    class Relations
    {
        public string Honnan { get; set; }
        public string Hova { get; set; }
        public string Tipus { get; set; }

        public Relations(string honnan, string hova,string tipus)
        {
            Honnan = honnan;
            Hova = hova;
            Tipus = tipus;
        }
    }
}