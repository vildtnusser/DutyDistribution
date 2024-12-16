using System.Transactions;
using NUnit.Framework;
using DutyDistribution.Components.Pages;
using DutyDistribution.Components.Shared;

namespace DutyDistributionTest;

public class DistributionPageBaseTest
{
    public static DistributionPageBase _distributionPageBase;
    public static DutyOverviewPageBase _dutyOverviewPageBase;
    public static PersonPageBase _personPageBase;
    
    public static void AddMultipleDuties(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            string testDutyName = $"TestDuty{i}";
            _dutyOverviewPageBase.addDutyToDB(testDutyName);
        }
    }
    public static void AddMultiplePersons(int amountToAdd){
        for (int i = 0; i < amountToAdd; i++)
        {
            string testPersonName = $"TestPerson{i}";
            _personPageBase.addPersonToDB(testPersonName);
        }
    }
    
    
    [SetUp]
    public void Setup()
    {
        var distributionPageBase = new DistributionPageBase();
        _distributionPageBase = distributionPageBase;
        
        var dutyOverviewPageBase = new DutyOverviewPageBase();
        _dutyOverviewPageBase= dutyOverviewPageBase;
        
        var personPageBase = new PersonPageBase();
        _personPageBase = personPageBase;

    }

    [Test]
    public void EqualAmountOfPersonAndDuties()
    {
        using (TransactionScope scope = new TransactionScope())
        {
            DataBase.OpenConnection();
            Utils.ClearDB();
            
            int amountOfPersonsToAdd = 4;
            int amountOfDutiesToAdd = 4;
            
            
            AddMultipleDuties(amountOfDutiesToAdd);
            AddMultiplePersons(amountOfPersonsToAdd);
            var distributedDuties = _distributionPageBase.DistributeDuties();
            
            Assert.That(distributedDuties.Count, Is.EqualTo(amountOfPersonsToAdd));
            Assert.That(distributedDuties[0].Count, Is.EqualTo(2));
            Assert.That(distributedDuties[1].Count, Is.EqualTo(2));
            Assert.That(distributedDuties[2].Count, Is.EqualTo(2));
            Assert.That(distributedDuties[3].Count, Is.EqualTo(2));
        }
    }
    [Test]
    public void MoreDutiesThanPersons()
    {
        using (TransactionScope scope = new TransactionScope())
        {
            DataBase.OpenConnection();
            Utils.ClearDB();
            
            int amountOfPersonsToAdd = 3;
            int amountOfDutiesToAdd = 4;
            
            
            AddMultipleDuties(amountOfDutiesToAdd);
            AddMultiplePersons(amountOfPersonsToAdd);
            var distributedDuties = _distributionPageBase.DistributeDuties();
            
            Assert.That(distributedDuties.Count, Is.EqualTo(amountOfPersonsToAdd));
            Assert.That(distributedDuties[0].Count, Is.EqualTo(3));
            Assert.That(distributedDuties[1].Count, Is.EqualTo(2));
            Assert.That(distributedDuties[2].Count, Is.EqualTo(2));
        }
    }
    [Test]
    public void LessDutiesThanPersons()
    {
        using (TransactionScope scope = new TransactionScope())
        {
            DataBase.OpenConnection();
            Utils.ClearDB();
            
            int amountOfPersonsToAdd = 4;
            int amountOfDutiesToAdd = 3;
            
            
            AddMultipleDuties(amountOfDutiesToAdd);
            AddMultiplePersons(amountOfPersonsToAdd);
            var distributedDuties = _distributionPageBase.DistributeDuties();
            
            Assert.That(distributedDuties.Count, Is.EqualTo(amountOfPersonsToAdd));
            Assert.That(distributedDuties[0].Count, Is.EqualTo(2));
            Assert.That(distributedDuties[1].Count, Is.EqualTo(2));
            Assert.That(distributedDuties[2].Count, Is.EqualTo(2));
            Assert.That(distributedDuties[3].Count, Is.EqualTo(1));
        }
    }
    
}
