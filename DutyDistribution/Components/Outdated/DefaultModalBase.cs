using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace DutyDistribution.Components.Outdated;

public class DefaultModalBase: ComponentBase
{
    public Modal modal = default!;


    public async Task OnShowModalClick()
    {
        await modal.ShowAsync();
    }

    public async Task OnHideModalClick()
    {
        await modal.HideAsync();
    }
}