using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


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
            var indexEnd = (j + 1) * amountOfDutiesForEachPerson;
          return new List<int>() {indexStart,indexEnd};

        }
    }

    //public Tuple<List<string>, List<string>> DistributeDuties(List<string> duties,List<string> persons, Boolean show)
    
    
    
    /* SIMPLE VERSION WORKS FINE FOR 2 PERSON, DISTRIBUTES EQUALLY WITH ALL UNEQUAL INDEXES BEING ASSIGN TO PERSON 2
     public Tuple<List<string>, List<string>> DistributeDuties(List<string> duties, Boolean show)
     {
         int N = duties.Count;
         int M = persons.Count;



          List<String> person1List = new(); //TODO remove
         List<String> person2List = new();//TODO remove
         foreach (string duty in duties)
         {
             int i = duties.IndexOf(duty);
             if (i % 2 == 0)
             {
                 person1List.Add(duty);
             }
             else
             {
                 person2List.Add(duty);
             }
         }
          if (show)
        {
            return Tuple.Create(person1List.Distinct().ToList(), person2List.Distinct().ToList());
        }
        else
        {
            return Tuple.Create(new List<String>()
                {
                    "Try to click distribute button again or check if no duties exists"
                },
                new List<String>()
                {
                    "Try to click distribute button again or check if no duties exists"
                });
        }
    }
         */

    public List<List<string>> DistributeDuties(List<string> duties, List<string> persons, Boolean show)
    {
        List<List<string>> dutyDistributions = new List<List<string>>();
        List<string> randomDuties = duties.OrderBy(_ => Random.Shared.Next()).ToList();
       


        foreach (var person in persons)
        {
            List<string> dutyList = new List<string>() { person };
            int indexStart = getDistributionIndexes( persons, duties, person)[0];
            int indexEnd = getDistributionIndexes( persons, duties, person)[1];
            Console.WriteLine("start index:" + indexStart + " end index:" + indexEnd + " for person " + person);

            foreach (string duty in randomDuties)
                //TODO ensure all duties gets distributed, at the moment there is a bug such that not all duties get distributed
            {
                int i = randomDuties.IndexOf(duty);
                if (Enumerable.Range(indexStart, indexEnd).Contains(i))
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
    
    
    public string nameTextField = "";

    public List<string> models = new()
    {
        "Cooking",
        "Cleaning"
    };
    
    public string nameTextFieldPerson = "";
    
    public List<string> persons = new()
    {
        "Person 1",
        "Person 2"
    };
}