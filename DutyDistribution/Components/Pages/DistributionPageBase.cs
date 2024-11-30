using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace DutyDistribution.Components.Pages;

public class DistributionPageBase : ComponentBase
{
    public DefaultModal defaultModal;
    public int currentCount = 0;
    public void DistributeDuties()
    {
        currentCount++;
    }
    
    
    public string nameTextField = "";

    public List<string> models = new()
    {
        "Cooking",
        "Cleaning"
    };
}