using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;


namespace DutyDistribution.Components.Pages;

public class DistributionPageBase : ComponentBase
{
    public Boolean show = false;
    public int currentCount = 0;

    public Tuple<List<string>, List<string>> DistributeDuties(List<string> duties, Boolean show)
    {
        List<String> personList = new()
        {
            "P1",
            "P2"
        };

        int N = duties.Count;
        int M = personList.Count;
        List<String> person1List = new();
        List<String> person2List = new();

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
    
    
    public string nameTextField = "";

    public List<string> models = new()
    {
        "Cooking",
        "Cleaning"
    };
}