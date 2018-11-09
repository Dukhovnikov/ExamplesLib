using NUnit.Framework;
using RestSharp;

namespace Tests.RestSharp
{
    public class PostSendingTest
    {
        [Test]
        public void Test()
        {
            var url = "";
            
            var restClient = new RestClient(url);
            var restRequest = new RestRequest(Method.POST) {Resource = "myendpoint"};

            restRequest.AddParameter("application/json", "{\"Some\":\"Json\"}", ParameterType.RequestBody);
            var response = restClient.Execute(restRequest);
        }
    }
}