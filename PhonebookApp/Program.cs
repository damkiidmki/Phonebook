using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhonebookApp.Services;

namespace PhonebookApp;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IPhonebookService, PhonebookService>();
                services.AddSingleton<Phonebook>();
                services.AddHostedService<Phonebook>();
            });
}