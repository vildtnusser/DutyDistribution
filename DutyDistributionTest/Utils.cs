using DutyDistribution.Components.Pages;

namespace DutyDistributionTest;

public static class Utils
{
    public static void ClearDB()
    {
        Duty.DeleteAllDuties();
        Person.DeleteAllPersons();
    }
}