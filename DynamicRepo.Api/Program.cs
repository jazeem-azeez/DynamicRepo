using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DynamicRepo.Api
{
    public class Program
    {
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
    }
}