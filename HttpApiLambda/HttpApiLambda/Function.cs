using System.Net;
using System.Net.Http;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace HttpApiLambda
{
    public class Function
    {
        private const string ThingOne = "{\"FirstName\":\"Thing\",\"LastName\":\"One\"}";
        private const string ThingTwo = "{\"FirstName\":\"Thing\",\"LastName\":\"Two\"}";

        public HttpResponseMessage GetThing(APIGatewayProxyRequest request, ILambdaContext context)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ThingOne)
            };
        }

        public HttpResponseMessage GetAllThings(APIGatewayProxyRequest request, ILambdaContext context)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent($"[{ThingOne},{ThingTwo}]")
            };
        }

        public HttpResponseMessage PostThing(APIGatewayProxyRequest request, ILambdaContext context)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ThingOne)
            };
        }

        public HttpResponseMessage DeleteThing(APIGatewayProxyRequest request, ILambdaContext context)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ThingOne)
            };
        }
    }
}
