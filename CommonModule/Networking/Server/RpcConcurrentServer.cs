using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Net.Sockets;
using System.Threading;
using CommonModule.Services;

namespace CommonModules.Networking.Server
{
    public class RpcConcurrentServer : AbsConcurrentServer
    {
        private IService server;

        public RpcConcurrentServer(int port, IService server) : base(port)
        {
            this.server = server;
            Console.WriteLine("RpcConcurrentServer initialized.");
        }

        public override Thread CreateWorker(TcpClient client)
        {
            CommonModules.Networking.RcpProtocol.ClientRpcReflectionWorker clientRpcReflectionWorker = new RcpProtocol.ClientRpcReflectionWorker(server, client);

            Thread thread = new Thread(new ThreadStart(clientRpcReflectionWorker.Run));
            return thread;
        }

        public void Stop()
        {
            Console.WriteLine("Stopping services...");
        }
    }
}
