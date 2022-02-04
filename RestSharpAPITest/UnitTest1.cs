using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RestSharp;
using System.Collections.Generic;

namespace RestSharpAPITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            var client = new RestClient("https://reqres.in/");

            var request = new RestRequest("/api/users?page=2");
            
            var result = await client.ExecuteAsync<string>(request);

            Assert.IsNull(result.Content);

        }
    }
}
