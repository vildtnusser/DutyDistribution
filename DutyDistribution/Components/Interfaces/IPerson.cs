using DutyDistribution.Components.Pages;

namespace DutyDistribution.Components.Interfaces;

public interface IPerson
{
    List<Person> GetAllPersons();
    int AddPerson(string name);
    int RemovePerson(int id);
}