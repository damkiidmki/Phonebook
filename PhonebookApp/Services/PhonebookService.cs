using PhonebookApp.Models;

namespace PhonebookApp.Services;

//todo лучше использовать using при работе с File
public class PhonebookService : IPhonebookService
{
    private const string ErrorMessage = "Аббонент уже добавлен";
    private const string Path = "phonebook.txt";
    public List<Abonent> Abonents = new List<Abonent>();

    public PhonebookService()
    {
        ReadFromFile();
    }
    
    public void AddPhoneNumber(Abonent abonent)
    {
        if (!CheckAbonent(abonent))
        {
            File.AppendAllText(Path, abonent.ToString() + '\n');
            Abonents.Add(abonent);
        }
        else
        {
            throw new Exception(ErrorMessage);
        }
    }

    public IList<Abonent> GetAbonents()
    { 
        return Abonents;
    }

    public void DeleteAbonent(Abonent abonent)
    {
        Abonents.Remove(abonent);
        UpdateFile();
    }

    public Abonent GetAbonentByPhone(string phone)
    {
        return Abonents.FirstOrDefault(x => x.Phone == phone);
    }

    public IEnumerable<Abonent> GetAbonentByName(string name)
    {
        return Abonents.Where(x => x.Name == name);
    }

    private bool CheckAbonent(Abonent abonent)
    {
        return Abonents.Contains(abonent);
    }

    private void UpdateFile()
    {
        File.WriteAllLines(Path, Abonents.Select(x =>  $"{x.Name} {x.Phone}") );
    }
    
    private void ReadFromFile()
    {
        InitFile();
        var abonents = File.ReadAllLines(Path);
        
        foreach (var abonentString in abonents)
        {
            var abonent = abonentString.Split(" ");
            Abonents.Add(new Abonent(abonent[0], abonent[1]));
        }
    }

    private void InitFile()
    {
        if (!File.Exists(Path))
        {
            var file = File.Create(Path);
            file.Close();
        }
    }
}