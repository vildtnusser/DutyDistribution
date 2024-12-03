using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;


namespace DutyDistribution.Components.Pages;

public class DistributionPageBase : ComponentBase
{
    public Boolean show = false;
    public int currentCount = 0;
    

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
        int N = duties.Count;
        int M = persons.Count;
        int amountOfDutiesForEachPerson = Convert.ToInt32(Math.Ceiling(N / (double)M));
        List<string> randomDuties = duties.OrderBy(_ => Guid.NewGuid()).ToList();
        Console.WriteLine("Random duties: " + randomDuties.ToList());

        foreach (var person in persons)
        {
            List<string> dutyList = new List<string>(){person};
            int j = persons.IndexOf(person);
            if (j == M - 1)
            {
                int a = N - amountOfDutiesForEachPerson;
                int b = N - 1;
            }

            else
            {
                int a = j * amountOfDutiesForEachPerson;
                int b = (j + 1) * amountOfDutiesForEachPerson;

            }
            
            // TODO get the distribution to work by getting the index definitions to work in the inner for loop, as it doesn't distribute correctly now

           /*int IndexStart = a;
            int IndexEnd = b;*/
            

            foreach (string duty in randomDuties)
            {
                int IndexStart = 0;
                int IndexEnd = amountOfDutiesForEachPerson;
                    
                int i = randomDuties.IndexOf(duty);
                if (Enumerable.Range(IndexStart, IndexEnd - IndexStart + 1).Contains(i))
                {
                    dutyList.Add(duty);
                }

                IndexStart = IndexEnd;
                IndexEnd = N-1;
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
    
    public List<string> persons = new()
    {
        "Person 1",
        "Person 2"
    };
}