using Autofac.Extensions.DependencyInjection;
using Elastic.CommonSchema.Serilog;
using Elastic.Apm.SerilogEnricher;
using Serilog;

namespace AgrotoolsMaps.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithElasticApmCorrelationInfo()
                .Enrich.FromLogContext()
                .WriteTo.Console(new EcsTextFormatter())
                .CreateLogger();

            try
            {
                Log.Information("Aplicação está iniciando...Hurrah!!!");
                CreateHostBuilder(args).Build().Run();
                Log.Information("Aplicação encerrada...zzzzzzz");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Um erro ocorreu durante a inicialização da aplicação. :´(");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(options =>
                    {
                        options.Limits.MaxRequestBufferSize = 302768;
                        options.Limits.MaxRequestLineSize = 302768;
                    });
                });
    }
}