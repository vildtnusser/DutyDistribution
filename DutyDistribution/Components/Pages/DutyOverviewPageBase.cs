using Microsoft.AspNetCore.Components;

namespace DutyDistribution.Components.Pages;

public class DutyOverviewPageBase : ComponentBase
{
    public string nameTextField = "";

    public List<string> models = new();
}