using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Training.CodersAcademy.MusicApp.Api
{
    /// <summary>
    /// The application program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="args">The arguments to run the application.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates a host.
        /// </summary>
        /// <param name="args">The arguments to run the application.</param>
        /// <returns>The host.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
