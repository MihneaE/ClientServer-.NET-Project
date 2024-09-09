using CommonModule.Services;
using CommonModules.Networking.Server;
using CommonModules.Networking.RcpProtocol;

namespace Client2
{

    internal static class Program
    {
        private static int defaultPort = 12345;
        private static string defaultServer = "localhost";

        public static void LoadProperties(Dictionary<string, string> props, string filePath)
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                {
                    var tokens = line.Split('=');
                    if (tokens.Length == 2)
                    {
                        props[tokens[0].Trim()] = tokens[1].Trim();
                    }
                }
            }
        }

        public static void ListProperties(Dictionary<string, string> props)
        {
            foreach (var prop in props)
            {
                Console.WriteLine($"{prop.Key}={prop.Value}");
            }
        }

        [STAThread]
        static void Main()
        {
            var clientProps = new Dictionary<string, string>();
            //string propertiesFilePath = Path.Combine("Client2", "client2.properties");

            try
            {
                //LoadProperties(clientProps, propertiesFilePath);
                Console.WriteLine("Client properties set:");
                ListProperties(clientProps);
            }
            catch (FileNotFoundException e)
            {
                Console.Error.WriteLine($"Cannot find client.properties: {e.Message}");
                return;
            }
            catch (IOException e)
            {
                Console.Error.WriteLine($"Error reading client.properties: {e.Message}");
                return;
            }

            string serverIP = clientProps.ContainsKey("server.host") ? clientProps["server.host"] : defaultServer;
            int serverPort = defaultPort;

            try
            {
                serverPort = int.TryParse(clientProps.GetValueOrDefault("server.port", defaultPort.ToString()), out int parsedPort) ? parsedPort : defaultPort;
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Wrong port number: {e.Message}");
                Console.WriteLine($"Using default port: {defaultPort}");
            }

            Console.WriteLine($"Connecting to {serverIP} on port {serverPort}...");

            IService service = new ServerRpcProxy(serverIP, serverPort);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(service));
        }
    }
}