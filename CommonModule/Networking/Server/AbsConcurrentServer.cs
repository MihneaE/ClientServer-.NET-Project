using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Net.Sockets;
using System.Threading;


namespace CommonModules.Networking.Server
{
    public abstract class AbsConcurrentServer : AbstractServer
    {
        public AbsConcurrentServer(int port) : base(port)
        {
            Console.WriteLine("Concurrent abstract server");
        }

        public override void ProcessRequest(TcpClient client)
        {
            Thread thread = CreateWorker(client);

            thread.Start();
        }

        public abstract Thread CreateWorker(TcpClient client);
    }
}
