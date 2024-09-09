using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CommonModules.Networking.Server
{
    public abstract class AbstractServer
    {
        private int port;
        private TcpListener serverSocket = null;

        public AbstractServer(int port)
        {
            this.port = port;
        }

        public void Start()
        {
            try
            {
                serverSocket = new TcpListener(IPAddress.Any, this.port);
                serverSocket.Start();

                Console.WriteLine("Waiting for clients");

                while (true)
                {
                    TcpClient client = serverSocket.AcceptTcpClient();

                    Console.WriteLine("Client connected");

                    ProcessRequest(client);
                }
            }
            catch (Exception ex)
            {
                throw new ServerException("Closing server error", ex);
            }
            
        }

        public void Stop()
        {
            try
            {
                serverSocket.Stop();
            }
            catch (Exception e)
            {
                throw new ServerException("Closing server error", e);
            }
        }

        public abstract void ProcessRequest(TcpClient client);
    }
}
