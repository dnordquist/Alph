using Alph.Lib;
using System;

namespace Alph.Domain
{
    public class RequestManager
    {
        public Response Response(Request incomingRequest)
        {
            return ProcessRequest(incomingRequest);
        }

        private Response ProcessRequest(Request incomingRequest)
        {
            Response r = new Response();
            return r;
        }
    }
}
