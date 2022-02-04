using Newtonsoft.Json;
using RestSharp;

namespace RestSharpAPI
{
    public class APIRequests
    {
        public string baseUrl = "https://reqres.in";

        public Pages GetListUsers(int page)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/api/users?page=" + page, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var users = JsonConvert.DeserializeObject<Pages>(content);

            return users;
        }

        public Datas GetUser(int id)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/api/users/" + id, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var user = JsonConvert.DeserializeObject<Datas>(content);

            return user;
        }

        public int UserNotFound(int id)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/api/users/" + id, Method.GET);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);
            var statusCode = (int)response.StatusCode;

            return statusCode;
        }

        public User CreateUser(User userDetails)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/api/users/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(userDetails);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var user = JsonConvert.DeserializeObject<User>(content);

            return user;
        }

        public User UpdateUserPutRequest(User userDetails, int id)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/api/users/" + id, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(userDetails);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var user = JsonConvert.DeserializeObject<User>(content);

            return user;
        }

        public User UpdateUserPatchRequest(User userDetails, int id)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/api/users/" + id, Method.PATCH);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(userDetails);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var user = JsonConvert.DeserializeObject<User>(content);

            return user;
        }

        public int DeleteUser(int id)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/api/users/" + id, Method.DELETE);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);
            var statusCode = (int)response.StatusCode;

            return statusCode;
        }

        public RegistrationAndLogin RegisterUser(RegistrationAndLogin regUser)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/api/register", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(regUser);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var registration = JsonConvert.DeserializeObject<RegistrationAndLogin>(content);

            return registration;
        }

        public RegistrationAndLogin LoginUser(RegistrationAndLogin regUser)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("/api/login", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(regUser);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var login = JsonConvert.DeserializeObject<RegistrationAndLogin>(content);

            return login;
        }
    }
}
