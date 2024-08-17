namespace PhonebookApp.Models;

/// <summary>
/// Абонент.
/// </summary>
public class Contact
{
    #region Property
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }
    #endregion
    
    #region Metods
    public override string ToString()
    {
        return $"{Name} {Phone}";
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is Contact contact)
            return Phone == contact.Phone;
        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Phone, Name);
    }
    #endregion

    #region Constructors
    public Contact()
    {
    }
    
    public Contact(string name, string phone)
    {
        Phone = phone;
        Name = name;
    }
    #endregion
}