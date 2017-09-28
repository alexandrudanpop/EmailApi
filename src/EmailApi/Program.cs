using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EmailApi
{
    class Program
    {
        static void Main(string[] args) =>
            new WebHostBuilder().UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build()
                .Run();
    }
}