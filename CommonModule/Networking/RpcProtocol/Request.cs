using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModules.Networking.RcpProtocol
{
    public class Request
    {
        public RequestType RequestType { get; set; }
        public object Data { get; set; }

        public Request() { }

        public override string ToString()
        {
            return $"Request{{ requestType={RequestType}, data={Data} }}";
        }

        public class Builder
        {
            public readonly Request _request = new Request();

            public Builder Type(RequestType requestType)
            {
                _request.RequestType = requestType;
                return this;
            }

            public Builder Data(object data)
            {
                _request.Data = data;
                return this;
            }

            public Request Build()
            {
                return _request;
            }
        }
    }
}
