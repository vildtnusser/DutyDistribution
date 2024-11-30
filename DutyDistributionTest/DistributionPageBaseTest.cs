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
    public void currentCountInitsTo0Test()
    {
        Assert.That(distributionPageBase.currentCount, Is.EqualTo(0));
    }
    
    
}
