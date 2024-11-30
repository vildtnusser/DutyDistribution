using Microsoft.AspNetCore.Components;

namespace DutyDistribution.Components.Pages;

public class CounterBase : ComponentBase
{
    public int currentCount = 0;

    public void IncrementCount()
    {
        currentCount++;
    }
    public void DecrementCount()
    {
        currentCount--;
    }
    
}