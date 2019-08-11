using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Convey.Logging;
using Ntrada;
using Ntrada.Hooks;

namespace NPost.APIGateway
{
    public static class Program
    {
        public static async Task Main(string[] args)
            => await WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddNtrada()
                    .AddSingleton<IBeforeHttpClientRequestHook, CorrelationContextHttpHook>())
                .Configure(app => app.UseNtrada())
                .UseLogging()
                .Build()
                .RunAsync();
    }
}