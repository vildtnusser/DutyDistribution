using Microsoft.AspNetCore.Components;

namespace DutyDistribution.Components.Pages;

public class DistributionPageBase : ComponentBase
{
    public Boolean show = false;
    public int currentCount = 0;
 

    public List<int> getDistributionIndexes(List<string> persons, List<string> duties, string person)
    {
        int N = duties.Count;
        int M = persons.Count;
        int amountOfDutiesForEachPerson = Convert.ToInt32(Math.Ceiling(N / (double)M));
        int j = persons.IndexOf(person);
        if (j == M - 1)
        {
            var indexStart = N - amountOfDutiesForEachPerson;
            var indexEnd = N - 1;
            return new List<int>(){indexStart,indexEnd};
        }

        else
        { 
            var indexStart = j * amountOfDutiesForEachPerson; 
            var indexEnd = (j + 1) * amountOfDutiesForEachPerson-1;
          return new List<int>() {indexStart,indexEnd};

        }
    }
    
    public List<List<string>> DistributeDuties(Boolean show)
    //TODO BUG: SOMETHING GOES WRONG when amount of person becomes 4 and amount of duties is > 4, probably something with index
    {
        List<Person> persons = DutyDistribution.Components.Pages.Person.getAllPersons();
        List<Duty> duties = DutyDistribution.Components.Pages.Duty.getAllDuties();
        List<string> personNames = persons.Select(p => p.Name).Distinct().ToList();
        List<string> dutyNames = duties.Select(d => d.Name).Distinct().ToList();
        
        List<List<string>> dutyDistributions = new List<List<string>>();
        List<string> randomDuties = dutyNames.OrderBy(_ => Random.Shared.Next()).ToList(); 

        foreach (var personName in personNames)
        {
            List<string> dutyList = new List<string>() { personName };
            int indexStart = getDistributionIndexes( personNames, dutyNames, personName)[0];
            int indexEnd = getDistributionIndexes( personNames, dutyNames, personName)[1];
            
       
            var  newList = dutyList.Concat(randomDuties[indexStart..(indexEnd+1)]);
            
            dutyDistributions.Add(newList.Distinct().ToList());
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