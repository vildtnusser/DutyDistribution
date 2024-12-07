using Microsoft.AspNetCore.Components;
using Npgsql;
namespace DutyDistribution.Components.Outdated;

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
   /* protected override async Task OnInitializedAsync()
    {
     
        var connString = "Host=127.0.0.1;Username=postgres;Password=admin;Database=postgres;";

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connString);
        var dataSource = dataSourceBuilder.Build();

        var conn = await dataSource.OpenConnectionAsync();
        
        
        
    }*/
}