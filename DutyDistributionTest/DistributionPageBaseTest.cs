using NUnit.Framework;
using DutyDistribution.Components.Pages;

namespace DutyDistributionTest;

public class DistributionPageBaseTest
{
    public DistributionPageBase distributionPageBase;
    
    [SetUp]
    public void Setup()
    {
        var _distributionPageBase = new DistributionPageBase();
        distributionPageBase = _distributionPageBase;
    }

    [Test]
    public void currentCountInitsTo0Test() //TODO remove when other unit tests is written
    {
        Assert.That(distributionPageBase.currentCount, Is.EqualTo(0));
    }
    
    
}
