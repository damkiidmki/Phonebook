using Microsoft.Extensions.Hosting;
using PhonebookApp.Models;
using PhonebookApp.Services;

namespace PhonebookApp;

//todo обработаны не все ошибки
public class Phonebook : IHostedService
{
    private readonly IPhonebookService _phonebookService;
    private readonly IHostApplicationLifetime _applicationLifetime;

    public Phonebook(IPhonebookService phonebookService,
        IHostApplicationLifetime applicationLifetime)
    {
        _phonebookService = phonebookService;
        _applicationLifetime = applicationLifetime;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        PrintAbonents(_phonebookService.GetAbonents());
        var q = true;
        while (q)
        {
            Info();
            var selectedCase = int.Parse(Console.ReadLine());

            try
            {
                switch (selectedCase)
                {
                    case 1:
                        _phonebookService.AddPhoneNumber(SetAbonent());
                        Console.WriteLine("Абонент добавлен");
                        break;
                    case 2:
                        _phonebookService.DeleteAbonent(SetAbonent());
                        Console.WriteLine("Абонент удален");
                        break;
                    case 3:
                        Console.WriteLine("Укажите номер телефона");
                        Console.WriteLine(_phonebookService.GetAbonentByPhone(Console.ReadLine()).ToString());
                        break;
                    case 4:
                        Console.WriteLine("Укажите имя");
                        var abobnents = _phonebookService.GetAbonentByName(Console.ReadLine());
                        foreach (var abonent in abobnents)
                        {
                            Console.WriteLine(abonent.ToString());
                        }
                        break;
                    case 5:
                        q = false;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        _applicationLifetime.StopApplication();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
    
    private Abonent SetAbonent()
    {
        Console.WriteLine("Укажите имя и номер в формете:{имя} {номер}");
        var input = Console.ReadLine().Split(' ');
        return new Abonent(input[0], input[1]);
    }

    private void PrintAbonents(IList<Abonent> abonents)
    { 
        if (abonents != null)
            foreach (var abonent in abonents)
            {
                Console.WriteLine(abonent);
            }
        else
        {
            Console.WriteLine("Абонентов нет");
        }
    }

    private void Info()
    {
        Console.WriteLine("Phonebook");
        Console.WriteLine("1 - Добавить абонента");
        Console.WriteLine("2 - Удалить абонента");
        Console.WriteLine("3 - Получить абонента по номеру телефона");
        Console.WriteLine("4 - Получить абонента по имени");
        Console.WriteLine("5 - Выход");
    }
}