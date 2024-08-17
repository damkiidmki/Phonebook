using PhonebookApp.Models;
using PhonebookApp.Services;

namespace PhonebookApp;

/// <summary>
/// Phonebook - класс для взаимодействия с пользователем через консоль.
/// </summary>
public class Phonebook
{
    private readonly IPhonebookManager _phonebookManager;
    
    /// <summary>
    /// Метод для работы с пользователем через консоль.
    /// </summary>
    public void ConsoleUI()
    {
        PrintContacts(_phonebookManager.GetContacts());
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
                        _phonebookManager.AddContact(SetContact());
                        Console.WriteLine("Абонент добавлен");
                        break;
                    case 2:
                        _phonebookManager.DeleteContact(SetContact());
                        Console.WriteLine("Абонент удален");
                        break;
                    case 3:
                        Console.WriteLine("Укажите номер телефона");
                        Console.WriteLine(_phonebookManager.GetContactByPhone(Console.ReadLine()).ToString());
                        break;
                    case 4:
                        Console.WriteLine("Укажите имя");
                        var contacts = _phonebookManager.GetContactByName(Console.ReadLine());
                        foreach (var contact in contacts)
                        {
                            Console.WriteLine(contact.ToString());
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
    }

    /// <summary>
    /// Получить с консоли данные об абоненте.
    /// </summary>
    /// <returns>Абонент.</returns>
    private Contact SetContact()
    {
        Console.WriteLine("Укажите имя и номер в формете:{имя} {номер}");
        var input = Console.ReadLine().Split(' ');
        return new Contact(input[0], input[1]);
    }

    /// <summary>
    /// Выгрузить в консоль всех абонентов.
    /// </summary>
    /// <param name="contacts"></param>
    private void PrintContacts(IList<Contact>? contacts)
    { 
        if (contacts != null)
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        else
        {
            Console.WriteLine("Абонентов нет");
        }
    }

    /// <summary>
    /// Информация для пользователя.
    /// </summary>
    private void Info()
    {
        Console.WriteLine("Phonebook");
        Console.WriteLine("1 - Добавить абонента");
        Console.WriteLine("2 - Удалить абонента");
        Console.WriteLine("3 - Получить абонента по номеру телефона");
        Console.WriteLine("4 - Получить абонента по имени");
        Console.WriteLine("5 - Выход");
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="phonebookManager"></param>
    public Phonebook(IPhonebookManager phonebookManager)
    {
        _phonebookManager = phonebookManager;
    }
}