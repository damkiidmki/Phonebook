namespace PhonebookApp.Models;

public class Abonent
{
    public string Phone { get; set; }

    public string Name { get; set; }

    public Abonent()
    {
    }
    
    public override string ToString()
    {
        return $"{Name} {Phone}";
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is Abonent abonent)
            return Phone == abonent.Phone;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Phone, Name);
    }

    public Abonent(string name, string phone)
    {
        Phone = phone;
        Name = name;
    }
}