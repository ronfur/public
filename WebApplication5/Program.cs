
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using WebApplication5.Models;

namespace WebApplication5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ModelContext ModelContext = new ModelContext())
            {
                ModelContext.Database.EnsureCreated();
            }

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
