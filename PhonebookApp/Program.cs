using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhonebookApp.Services;

namespace PhonebookApp;

public class Program
{
    /// <summary>
    /// Точка входа.
    /// </summary>
    /// <param name="args">Не используются в приложении.</param>
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    /// <summary>
    /// Запуск фоновой задачи
    /// </summary>
    /// <param name="args">Не используются в приложении.</param>
    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IPhonebookManager, PhonebookManager>();
                services.AddSingleton(typeof(Phonebook));
                services.AddHostedService<HostedService>();
            });
}