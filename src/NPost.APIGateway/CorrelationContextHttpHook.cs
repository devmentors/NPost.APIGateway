using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using Newtonsoft.Json;
using Ntrada;
using Ntrada.Hooks;

namespace NPost.APIGateway
{
    public class CorrelationContextHttpHook : IBeforeHttpClientRequestHook
    {
        public void Invoke(HttpClient client, ExecutionData data)
        {
            var context = new CorrelationContext
            {
                CorrelationId = data.RequestId,
                UserId = data.UserId,
                Role = data.Claims.FirstOrDefault(c => c.Key == ClaimTypes.Role).Value,
                Claims = data.Claims
            };

            client.DefaultRequestHeaders.TryAddWithoutValidation("Correlation-Context",
                JsonConvert.SerializeObject(context));
        }
    }
}