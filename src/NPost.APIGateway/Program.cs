using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Ntrada;

namespace NPost.APIGateway
{
    public static class Program
    {
        public static async Task Main(string[] args)
            => await WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddNtrada())
                .Configure(app => app
                    .UseNtrada())
                .Build()
                .RunAsync();
    }
}