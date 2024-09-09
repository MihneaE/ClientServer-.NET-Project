using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonModules.Services;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CommonModule.Services;
using CommonModule.Model;

namespace CommonModules.Networking.RcpProtocol
{
    public class ServerRpcProxy : IService
    {
        private string host;
        private int port;
        private Observer client;
        private TcpClient connection;
        private BinaryReader reader;
        private BinaryWriter writer;
        private BlockingCollection<Response> responses;
        private volatile bool finished;

        public ServerRpcProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            this.responses = new BlockingCollection<Response>();
        }

        public User loginUser(string username, string password, Observer client)
        {
            InitializeConnection(); 

            var credentials = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            var request = new Request.Builder() 
                            .Type(RequestType.LOGIN)
                            .Data(credentials)
                            .Build();
            SendRequest(request); 

            var response = ReadResponse();

            if (response.ResponseType == ResponseType.OK)
            {
                this.client = client;

                User user = JsonConvert.DeserializeObject<User>(response.Data.ToString());
                return user;
            }

            if (response.ResponseType == ResponseType.ERROR)
            {
                string err = response.Data.ToString();
                CloseConnection(); 
                throw new ServiceException(err);
            }

            return null;
        }

        public void logoutUser(User user, Observer client)
        {
            Request request = new Request.Builder().Type(RequestType.LOGOUT).Data(user).Build();
            SendRequest(request);

            Response response = ReadResponse();

            CloseConnection();

            if (response.ResponseType == ResponseType.ERROR)
            {
                string err = response.Data.ToString();
                throw new ServiceException(err);
            }
        }

        public void registerMan(int id, int sample_id, string name, int age)
        {
            Man man = new Man(id, sample_id, name, age);

            Request request = new Request.Builder().Type(RequestType.REGISTER).Data(man).Build();
            SendRequest(request);

            Response response = ReadResponse();

            if (response.ResponseType == ResponseType.ERROR)
            {
                string err = response.Data.ToString();
                throw new ServiceException(err);
            }
        }

        public List<Man> findManFromSpecificCompetitionFS(string sample, string ageCategory)
        {
            var credentials = new Dictionary<string, string>
            {
                { "sample", sample },
                { "ageCategory", ageCategory }
            };

            Request request = new Request.Builder().Type(RequestType.SEARCH).Data(credentials).Build();
            SendRequest(request);

            Response response = ReadResponse();

            if (response.ResponseType == ResponseType.ERROR)
            {
                string err = response.Data.ToString();
                throw new ServiceException(err);
            }

            try
            {
                List<Man> men = JsonConvert.DeserializeObject<List<Man>>(response.Data.ToString());
                return men;
            }
            catch (JsonException je)
            {
                throw new ServiceException("Failed to deserialize the response data: " + je.Message);
            }
        }

        public List<Man> GetAllMenFS()
        {
            return null;
        }
        public List<User> GetAllUsersFS()
        {
            return null;
        }
        public  List<Competition> GetAllCompetitionsFS()
        {
            Request request = new Request.Builder().Type(RequestType.GET_ALL).Build();
            SendRequest(request);

            Response response = ReadResponse();

            if (response.ResponseType == ResponseType.ERROR)
            {
                string err = response.Data.ToString();
                throw new ServiceException(err);
            }

            List<Competition> competitions = JsonConvert.DeserializeObject<List<Competition>>(response.Data.ToString());
            return competitions;
        }

        public void InitializeConnection()
        {
            try
            {
                connection = new TcpClient(host, port);
                var stream = connection.GetStream();
                writer = new BinaryWriter(stream);
                reader = new BinaryReader(stream);

                finished = false;
                StartReader();
            }
            catch (SocketException ex)
            {
                throw new ServiceException("Cannot connect to server.", ex);
            }
            catch (IOException ex)
            {
                throw new ServiceException("Failed to create streams.", ex);
            }
        }

        public void StartReader()
        {
            Thread thread = new Thread(new ThreadStart(ReaderThread));
            thread.Start();
        }

        public void CloseConnection()
        {
            finished = true;
            try
            {
                reader.Close();
                writer.Close();
                connection.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SendRequest(Request request)
        {
            try
            {
                var requestSerialized = SerializeRequest(request);
                writer.Write(requestSerialized);
                writer.Flush();
            }
            catch (IOException ex)
            {
                throw new ServiceException("Error sending request.", ex);
            }
        }

        public Response ReadResponse()
        {
            try
            {
                return responses.Take();
            }
            catch (InvalidOperationException ex)
            {
                throw new ServiceException("Error reading response.", ex);
            }
        }

        public void HandleUpdate()
        {
            client.UpdateCompetitions();
        }

        public bool IsUpdate(Response response)
        {
            return response.ResponseType == ResponseType.UPDATE;
        }

        public void ReaderThread()
        {
            while (!finished)
            {
                try
                {
                    var responseSerialized = reader.ReadString();
                    var response = DeserializeResponse(responseSerialized);

                    if (IsUpdate(response))
                    {
                        HandleUpdate();
                    }
                    else
                    {
                        responses.Add(response);
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Reader thread terminated: " + ex.Message);
                    break;
                }
            }
        }

        public string SerializeRequest(Request request)
        {
            return JsonConvert.SerializeObject(request);
        }

        public Response DeserializeResponse(string responseSerialized)
        {
            return JsonConvert.DeserializeObject<Response>(responseSerialized);
        }
    }
}
