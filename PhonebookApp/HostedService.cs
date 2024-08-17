using Microsoft.Extensions.Hosting;

namespace PhonebookApp;

/// <summary>
/// Размещенная служба 
/// </summary>
public class HostedService : IHostedService
{
    private readonly Phonebook _phonebook;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    
    /// <summary>
    /// Вызывается, когда приложение готово запустить фоновую службу
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _phonebook.ConsoleUI();
        _hostApplicationLifetime.StopApplication();
        return Task.CompletedTask;
    }

    /// <summary>
    /// Вызывается, когда происходит нормальное завершение работы узла приложения.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="phonebook">Телефонный справочник, UI</param>
    /// <param name="hostApplicationLifetime">Используется для закрытия приложения.</param>
    public HostedService(Phonebook phonebook,
        IHostApplicationLifetime hostApplicationLifetime)
    {
        _phonebook = phonebook;
        _hostApplicationLifetime = hostApplicationLifetime;
    }
}