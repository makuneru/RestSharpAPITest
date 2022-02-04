using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpAPI;

namespace APITesting
{
    [TestClass]
    public class BasicEndpointTest
    {
        [TestMethod]
        public void ListOfUsersTest()
        {
            var getListUsers = new APIRequests();
            var resListUsers = getListUsers.GetListUsers(2); 
            Assert.AreEqual(resListUsers.Page, 2); //get users from page 2
            Assert.AreEqual(resListUsers.Per_Page, 6); //6 users per page
            Assert.AreEqual(resListUsers.Total_Pages, 2); // total pages
            Assert.AreEqual(resListUsers.Total, 12); //total number of users
            Assert.AreEqual(resListUsers.Data.Count, 6); //6 users per page
        }

        [TestMethod]
        public void GetUserTest()
        {
            var getUser = new APIRequests();
            var resUser = getUser.GetUser(2);
            Assert.AreEqual(resUser.Data.Id, 2); //verify id
            //Verify user details
            Assert.AreEqual(resUser.Data.First_Name, "Janet"); 
            Assert.AreEqual(resUser.Data.Last_Name, "Weaver");
            Assert.AreEqual(resUser.Data.Email, "janet.weaver@reqres.in");
        }

        [TestMethod]
        public void SingleUserNotFoundTest()
        {
            var userNotFound = new APIRequests();
            var resStatusCode = userNotFound.UserNotFound(99);
            //Verify response code for not found
            Assert.AreEqual(resStatusCode, 404);

        }

        [TestMethod]
        public void CreateUserTest()
        {
            var user = new User();
            user.Name = "morpheus";
            user.Job = "leader";

            var getUser = new APIRequests();
            var newUser = getUser.CreateUser(user);
            //Verify created user details
            Assert.AreEqual(newUser.Name, "morpheus");
            Assert.AreEqual(newUser.Job, "leader");

        }

        [TestMethod]
        public void UpdateUserPUTRequestTest()
        {
            var user = new User();
            user.Name = "morpheus";
            user.Job = "Test Automation Eng";

            var getUser = new APIRequests();
            var updatedUser = getUser.UpdateUserPutRequest(user, 2);
            //Verify updated user details
            Assert.AreEqual(updatedUser.Name, "morpheus");
            Assert.AreEqual(updatedUser.Job, "Test Automation Eng");

        }

        [TestMethod]
        public void UpdateUserPatchRequestTest()
        {
            var user = new User();
            user.Name = "morpheus";
            user.Job = "Test Lead";

            var getUser = new APIRequests();
            var updatedUser = getUser.UpdateUserPutRequest(user, 2);
            //Verify updated user details
            Assert.AreEqual(updatedUser.Name, "morpheus");
            Assert.AreEqual(updatedUser.Job, "Test Lead");

        }

        [TestMethod]
        public void DeleteUserTest()
        {
            var deleteUser = new APIRequests();
            var resStatusCode = deleteUser.DeleteUser(2);
            //Verify response code
            Assert.AreEqual(resStatusCode, 204);

        }

        [TestMethod]
        public void SuccessfulRegistrationTest()
        {
            var registration = new RegistrationAndLogin();
            registration.email = "eve.holt@reqres.in";
            registration.password = "pistol";

            var user = new APIRequests();
            var regUser = user.RegisterUser(registration);
            //Verify id and token response
            Assert.IsNotNull(regUser.Id);
            Assert.IsNotNull(regUser.Token);
        }

        [TestMethod]
        public void UnsuccessfulRegistrationTest()
        {
            var registration = new RegistrationAndLogin();
            registration.email = "eve.holt@reqres.in";

            var user = new APIRequests();
            var regUser = user.RegisterUser(registration);
            //Verify error message
            Assert.AreEqual(regUser.Error, "Missing password");
        }

        [TestMethod]
        public void SuccessfulLoginTest()
        {
            var login = new RegistrationAndLogin();
            login.email = "eve.holt@reqres.in";
            login.password = "cityslicka";

            var user = new APIRequests();
            var regUser = user.RegisterUser(login);
            //Verify token response
            Assert.IsNotNull(regUser.Token);
        }

        [TestMethod]
        public void UnsuccessfulLoginTest()
        {
            var login = new RegistrationAndLogin();
            login.password = "cityslicka";

            var user = new APIRequests();
            var regUser = user.RegisterUser(login);
            //Verify error message
            Assert.AreEqual(regUser.Error, "Missing email or username");
        }
    }
}
