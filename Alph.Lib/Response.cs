using System;
using System.Collections.Generic;

namespace Alph.Lib
{
    public class Response
    {
        public string InputName { get; set; }
        public string SortedName { get; set; }
        public ResponseCode ReturnedCode { get; set; }

        public List<SortFact> ReturnedSortFacts{get; set;}

        public Response()
        {
            ReturnedSortFacts = new List<SortFact>();
        }

    }
}
