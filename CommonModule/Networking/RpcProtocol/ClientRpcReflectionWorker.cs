using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonModule.Services;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CommonModule.Model;

namespace CommonModules.Networking.RcpProtocol
{
    public class ClientRpcReflectionWorker : CommonModules.Services.Observer
    {
        private IService server;
        private TcpClient connection;
        private BinaryReader input;
        private BinaryWriter output;
        private volatile bool connected;

        public ClientRpcReflectionWorker(IService server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;

            try
            {
                var stream = connection.GetStream();
                output = new BinaryWriter(stream);
                input = new BinaryReader(stream);
                connected = true;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Run()
        {
            Thread thread = new Thread(RunClient);
            thread.Start();
        }

        private void RunClient()
        {
            while (connected)
            {
                try
                {
                    var requestSerialized = input.ReadString();
                    var request = DeserializeRequest(requestSerialized);
                    var response = HandleRequest(request);
                    if (response != null)
                    {
                        SendResponse(response);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.ToString());
                }

                Thread.Sleep(1000);
            }

            CloseConnection();
        }

        private Response HandleRequest(Request request)
        {
            Response response = null;

            switch (request.RequestType)
            {
                case RequestType.LOGIN:
                    response = HandleLogin(request);
                    break;
                case RequestType.LOGOUT:
                    response = HandleLogout(request);
                    break;
                case RequestType.SEARCH:
                    response = HandleSearch(request);
                    break;
                case RequestType.REGISTER:
                    response = HandleRegister(request);
                    break;
                case RequestType.GET_ALL:
                    response = HandleGetAll(request);
                    break;
                default:
                    Console.WriteLine("Unhandled request type: " + request.RequestType);
                    string message = "Unhandled request";
                    response = new Response.Builder().Type(ResponseType.ERROR).Data(message).Build();
                    break;
            }

            Console.WriteLine("Method for " + request.RequestType + " invoked");
            return response;
        }

        private static Response okResponse = new Response.Builder().Type(ResponseType.OK).Build();

        public Response HandleLogin(Request request)
        {
            Console.WriteLine("Login request" + request.RequestType);
            //CommonModule.Model.User user = (User)request.Data;

            try
            {
                JObject jsonData = request.Data as JObject;

                if (jsonData == null)
                {
                    throw new InvalidOperationException("Data is not a valid JSON object.");
                }

                User user = jsonData.ToObject<User>();

                server.loginUser(user.GetUsername(), user.GetPassword(), this);
                return new Response.Builder().Type(ResponseType.OK).Data(user).Build();
            }
            catch (Exception e)
            {
                connected = false;
                return new Response.Builder().Type(ResponseType.ERROR).Data(e).Build();
            }
        }

        public Response HandleLogout(Request request)
        {
            Console.WriteLine("Logout request" + request.RequestType);
            User user = JsonConvert.DeserializeObject<User>(request.Data.ToString());

            try
            {
                server.logoutUser(user, this);
                connected = false;
                return okResponse;
            }
            catch (Exception e)
            {
                connected = false;
                return new Response.Builder().Type(ResponseType.ERROR).Data(e).Build();
            }
        }

        public Response HandleGetAll(Request request)
        {
            Console.WriteLine("Get All request");

            try
            {
                List<Competition> competitions = server.GetAllCompetitionsFS();
                return new Response.Builder().Type(ResponseType.OK).Data(competitions).Build();
            }
            catch (Exception e)
            {
                return new Response.Builder().Type(ResponseType.ERROR).Data(e).Build();
            }
        }

        public Response HandleSearch(Request request)
        {
            Console.WriteLine("Search request...");

            var parameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(request.Data.ToString());

            if (!parameters.ContainsKey("sample") || !parameters.ContainsKey("ageCategory"))
            {
                Console.WriteLine("Required parameters are missing");
                return new Response.Builder().Type(ResponseType.ERROR).Data("Missing parameters").Build();
            }

            string sample = parameters["sample"];
            string ageCategory = parameters["ageCategory"];

            try
            {
                List<Man> mans = server.findManFromSpecificCompetitionFS(sample, ageCategory);
                return new Response.Builder().Type(ResponseType.OK).Data(mans).Build();
            }
            catch (CommonModules.Services.ServiceException e) {
                return new Response.Builder().Type(ResponseType.ERROR).Data(e).Build();
            }
        }

        public Response HandleRegister(Request request)
        {
            Console.WriteLine("ADD request...");

            Man man = JsonConvert.DeserializeObject<Man>(request.Data.ToString());

            try
            {
                server.registerMan(man.id, man.sample_id, man.name, man.age);
                return okResponse;
            }
            catch (CommonModules.Services.ServiceException e) {
                return new Response.Builder().Type(ResponseType.ERROR).Data(e).Build();
            }
            }

        public void CloseConnection()
        {
            try
            {
                input.Close();
                output.Close();
                connection.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error " + e);
            }
        }

        public void UpdateCompetitions()
        {
            Response response = new Response.Builder().Type(ResponseType.UPDATE).Build();
            Console.WriteLine("UPDATE AT CLIENT");

            try
            {
                SendResponse(response);
            }
            catch (IOException e)
            {
                throw new IOException("Failed to send update notification.", e);
            }
        }

        public void SendResponse(Response response)
        {
            Console.WriteLine("Sending response: " + response);

            lock (output)
            {
                var responseSerialized = SerializeResponse(response);
                output.Write(responseSerialized);
                output.Flush();
            }
        }

        private Request DeserializeRequest(string requestSerialized)
        {
            return JsonConvert.DeserializeObject<Request>(requestSerialized);
        }

        private string SerializeResponse(Response response)
        {
            return JsonConvert.SerializeObject(response);
        }
    }
}
