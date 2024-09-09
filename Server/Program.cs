
using CommonModule.Repository;
using CommonModule.Model;
using CommonModule.Services;
using CommonModules.Networking.RcpProtocol;
using CommonModules.Networking.Server;
using Server.ServiceS;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Server
{
    internal static class Program
    {

        private static int defaultPort = 12345;

        [STAThread]
        static void Main()
        {
            Console.WriteLine("x");


            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            SQLitePCL.raw.FreezeProvider(true);

            var serverProperties = new Dictionary<string, string>();
            string propertiesFilePath = Path.Combine("Server", "server.properties");

            try
            {
                foreach (var line in File.ReadAllLines(propertiesFilePath))
                {
                    if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                    {
                        var tokens = line.Split('=');
                        if (tokens.Length == 2)
                        {
                            serverProperties[tokens[0].Trim()] = tokens[1].Trim();
                        }
                    }
                }

                Console.WriteLine("Server properties set.");
                foreach (var key in serverProperties.Keys)
                {
                    Console.WriteLine($"{key}={serverProperties[key]}");
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine($"Cannot find server.properties in Server module! {e}");
            }

            List<Man> men;
            List<User> users;
            List<Competition> competitions;

            DataBaseInitializerRepository.SeedDatabase();
            var context = new DatabaseRepository();

            men = context.Men.ToList();
            users = context.Users.ToList();
            competitions = context.Competitions.ToList();

            var repository = new InMemoryRepository(men, users, competitions);

            IService serverImpl = new Service(repository, context);

            int serverPort = defaultPort;

            try
            {
                if (serverProperties.ContainsKey("server.port") && !int.TryParse(serverProperties["server.port"], out serverPort))
                {
                    throw new FormatException("The provided port is not a valid integer.");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Wrong port number: " + e.Message);
                Console.WriteLine("Using default port: " + defaultPort);
                serverPort = defaultPort; 
            }

            AbstractServer server = new RpcConcurrentServer(serverPort, serverImpl);

            Console.WriteLine("Starting server on port: " + serverPort);

            try
            {
                server.Start();
            }
            catch (ServerException e)
            {
                Console.WriteLine("Error starting the server " + e);
            }
            finally
            {
                try
                {
                    server.Stop();
                }
                catch (ServerException e)
                {
                    Console.WriteLine("Error stopping the server " + e);
                }
            }
        }
    }
}