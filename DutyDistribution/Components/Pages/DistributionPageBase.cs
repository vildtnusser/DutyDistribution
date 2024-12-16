using Microsoft.AspNetCore.Components;

namespace DutyDistribution.Components.Pages;

public class DistributionPageBase : ComponentBase
{
    public List<List<string>> distributedDuties = new();
    public List<List<string>> DistributeDuties()
    {
        List<Person> persons = Person.GetAllPersons();
        List<Duty> duties = Duty.GetAllDuties();
        List<string> personNames = persons.Select(p => p.Name).Distinct().ToList();
        List<string> dutyNames = duties.Select(d => d.Name).Distinct().ToList();
        
        List<List<string>> dutyDistributions = new List<List<string>>();
        List<string> randomDuties = dutyNames.OrderBy(_ => Random.Shared.Next()).ToList(); 
        
        int M = persons.Count;
        foreach (var personName in personNames)
        {
            List<string> dutyList = new List<string>() { personName };
            int i = personNames.IndexOf(personName);
            foreach (var duty in randomDuties)
            {
                int j = randomDuties.IndexOf(duty);
                if ((j % M) == i)
                {
                    dutyList.Add(duty);
                }


            }
            dutyDistributions.Add(dutyList.Distinct().ToList());
        }

 
        return dutyDistributions;
    }
}