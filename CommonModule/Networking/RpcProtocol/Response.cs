using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModules.Networking.RcpProtocol
{
    public class Response
    {
        public ResponseType ResponseType { get; set; }
        public object Data { get; set; }

        public Response()
        { }

        public override string ToString()
        {
            return $"Response{{ responseType={ResponseType}, data={Data} }}";
        }

        public class Builder
        {
            private readonly Response _response = new Response();

            public Builder Type(ResponseType responseType)
            {
                _response.ResponseType = responseType;
                return this;
            }

            public Builder Data(object data)
            {
                _response.Data = data;
                return this;
            }

            public Response Build()
            {
                return _response;
            }
        }
    }
}
