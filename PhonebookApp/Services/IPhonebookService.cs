using PhonebookApp.Models;

namespace PhonebookApp.Services;

public interface IPhonebookService
{
    public void AddPhoneNumber(Abonent abonent);

    public IList<Abonent> GetAbonents();

    public void DeleteAbonent(Abonent abonent);

    public Abonent GetAbonentByPhone(string phone);
    
    public IEnumerable<Abonent> GetAbonentByName(string name);
}