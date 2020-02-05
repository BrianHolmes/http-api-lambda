using System;
using System.Collections.Generic;
using System.Net;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace HttpApiLambda
{
    public class Function
    {
        private readonly Thing _thingOne = new Thing {FirstName = "Thing", LastName = "One"};
        private readonly Thing _thingTwo = new Thing {FirstName = "Thing", LastName = "Two"};

        public APIGatewayProxyResponse GetThing(APIGatewayProxyRequest request, ILambdaContext context)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                Body = JsonConvert.SerializeObject(_thingOne)
            };
        }

        public APIGatewayProxyResponse GetAllThings(APIGatewayProxyRequest request, ILambdaContext context)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                Body = JsonConvert.SerializeObject(new List<Thing>{_thingOne, _thingTwo})
            };
        }

        public APIGatewayProxyResponse PostThing(APIGatewayProxyRequest request, ILambdaContext context)
        {
            if (!string.IsNullOrWhiteSpace(request.Body)) _thingOne.Notes = request.Body;

            return new APIGatewayProxyResponse
            {
                StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                Body = JsonConvert.SerializeObject(_thingOne)
            };
        }

        public APIGatewayProxyResponse DeleteThing(APIGatewayProxyRequest request, ILambdaContext context)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = Convert.ToInt32(HttpStatusCode.NoContent)
            };
        }
    }

    public class Thing
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
    }
}
