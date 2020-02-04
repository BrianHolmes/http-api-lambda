using Amazon.Lambda.APIGatewayEvents;
using Xunit;
using Amazon.Lambda.TestUtilities;

namespace HttpApiLambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestLambdaFunctions()
        {
            var function = new Function();
            var context = new TestLambdaContext();
            var getThingResponse = function.GetThing(new APIGatewayProxyRequest(), context);
            var getAllThingsResponse = function.GetAllThings(new APIGatewayProxyRequest(), context);
            var postThingResponse = function.PostThing(new APIGatewayProxyRequest(), context);
            var deleteThingResponse = function.DeleteThing(new APIGatewayProxyRequest(), context);
        }
    }
}
