using PhonebookApp.Models;

namespace PhonebookApp.Services;

/// <summary>
/// Содержит методы для работы с абонентами.
/// </summary>
public interface IPhonebookManager
{ 
    /// <summary>
    /// Добавить абонента.
    /// </summary>
    /// <param name="contact">Абонент</param>
    void AddContact(Contact contact);
    
    /// <summary>
    /// Получить список всех абонентов.
    /// </summary>
    /// <returns>Возвращает всех абонентов.</returns>
    IList<Contact>? GetContacts();

    /// <summary>
    /// Удалить абонента.
    /// </summary>
    /// <param name="contact">Абонент.</param>
    void DeleteContact(Contact contact);

    /// <summary>
    /// Получить абонента по номеру телефона.
    /// </summary>
    /// <param name="phone">Номер телефона.</param>
    /// <returns>Найденный абонент.</returns>
    Contact GetContactByPhone(string phone);
    
    /// <summary>
    /// Получить абонентов по имени.
    /// </summary>
    /// <param name="name">Имя абонента.</param>
    /// <returns>Найденнные абоненты.</returns>
    IEnumerable<Contact> GetContactByName(string name);
}