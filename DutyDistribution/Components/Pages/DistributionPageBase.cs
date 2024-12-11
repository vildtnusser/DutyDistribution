using Microsoft.AspNetCore.Components;

namespace DutyDistribution.Components.Pages;

public class DistributionPageBase : ComponentBase
{
    public Boolean show = false;
    public int currentCount = 0; //TODO remove, when unit tests rewritten
    
    public List<List<string>> DistributeDuties(Boolean show)
    {
        List<Person> persons = Person.getAllPersons();
        List<Duty> duties = Duty.getAllDuties();
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

        
        var dutyTuple = new List<List<string>>();
        List<string> NoDistribution = new List<string>(){"Try to click distribute button again or check if no duties exists"};

        foreach (var dutyList in dutyDistributions)
        {
            if (show)
            {
                dutyTuple.Add(dutyList.Distinct().ToList());
            }
            else
            {
                dutyTuple.Add(NoDistribution.Distinct().ToList());
            }
        }

        return dutyTuple;
    }
    public List<List<string>> distributedDuties = new();

}