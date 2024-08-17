using PhonebookApp.Models;

namespace PhonebookApp.Services;

//TODO Вынести путь к файлу в какой-либо конфиг. Перенести методы создания файла в момент старта приложения. 
/// <summary>
/// PhonebookManager содержит CRUD функциональность. Работает с текстовым файлом. 
/// </summary>
public class PhonebookManager : IPhonebookManager
{
    #region Consts
    /// <summary>
    /// Сообщение об ошибке.
    /// </summary>
    private const string ErrorMessage = "Аббонент уже добавлен";
    
    /// <summary>
    /// Можно указать путь к файлу. Используется по умолчанию.
    /// </summary>
    private const string Path = "phonebook.txt";
    #endregion

    #region Property
    /// <summary>
    /// Список абонентов.
    /// </summary>
    private List<Contact>? _contacts = new List<Contact>();
    #endregion

    #region Metods
    public void AddContact(Contact contact)
    {
        if (!CheckContact(contact))
        {
            File.AppendAllText(Path, contact.ToString() + '\n');
            _contacts.Add(contact);
        }
        else
        {
            throw new Exception(ErrorMessage);
        }
    }

    public IList<Contact>? GetContacts()
    { 
        return _contacts;
    }

    public void DeleteContact(Contact contact)
    {
        _contacts.Remove(contact);
        UpdateFile();
    }

    public Contact GetContactByPhone(string phone)
    {
        return _contacts.FirstOrDefault(x => x.Phone == phone);
    }

    public IEnumerable<Contact> GetContactByName(string name)
    {
        return _contacts.Where(x => x.Name == name);
    }

    /// <summary>
    /// Проверяет наличие абонента по номеру телефона.
    /// </summary>
    /// <param name="contact">Абонент.</param>
    /// <returns>True или False.</returns>
    private bool CheckContact(Contact contact)
    {
        return _contacts.Contains(contact);
    }

    /// <summary>
    /// Обновляет файл.
    /// </summary>
    private void UpdateFile()
    {
        File.WriteAllLines(Path, _contacts.Select(x =>  $"{x.Name} {x.Phone}") );
    }
    
    /// <summary>
    /// Получаем абонентов из файла. 
    /// </summary>
    private void ReadFromFile()
    {
        InitFile();
        var contacts = File.ReadAllLines(Path);
        
        foreach (var contactString in contacts)
        {
            var contact = contactString.Split(" ");
            _contacts.Add(new Contact(contact[0], contact[1]));
        }
    }

    /// <summary>
    /// Проверяет наличие файла, если его нет, тогда создаст новый.
    /// </summary>
    private void InitFile()
    {
        if (!File.Exists(Path))
        {
            var file = File.Create(Path);
            file.Close();
        }
    }
    #endregion

    #region Constructors
    /// <summary>
    /// Конструктор по умолчанию. Берет данные из файла.
    /// </summary>
    public PhonebookManager()
    {
        ReadFromFile();
    }
    #endregion
}