using NUnit.Framework;
using DutyDistribution.Components.Pages;


namespace DutyDistributionTest;

public class Tests
{
    public CounterBase counterBase;
    
    [SetUp]
    public void Setup()
    {
         var _counterBase = new CounterBase();
         counterBase = _counterBase;
    }

    [Test]
    public void currentCountInitsTo0Test()
    {
        Assert.That(counterBase.currentCount, Is.EqualTo(0));
    }
    
    
}
