using DutyDistribution.Components.Pages;
using Moq;
using System.Collections.Generic;
using System.Transactions;
using DutyDistribution.Components.Interfaces;
using DutyDistribution.Components.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DutyDistributionTest
{
    public class DutyOverviewPageBaseTest
    {
        private static DutyOverviewPageBase _dutyOverviewPageBase;

        public static bool DutyExists(string dutyName)
        {
            var allDuties = Duty.GetAllDuties();
            return (allDuties.Where(d => d.Name == dutyName).Count() > 0);

        }

        [SetUp]
        public void Setup()
        {
            var dutyOverviewPageBase = new DutyOverviewPageBase();
            _dutyOverviewPageBase = dutyOverviewPageBase;
        }

        [Test]
        public void AddDutyTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                //TODO Flush DB
                DataBase.OpenConnection();
                var newDutyName = "Duty Test";
                Assert.That(DutyExists(newDutyName), Is.False);

                _dutyOverviewPageBase.addDutyToDB(newDutyName);

                Assert.That(DutyExists(newDutyName), Is.True);
            }
        }

        [Test]
        public void removeDutyTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                //TODO Flush DB
                DataBase.OpenConnection();
                string testDutyName = "Duty Test";
                _dutyOverviewPageBase.addDutyToDB(testDutyName);
                List<Duty> allDuties = Duty.GetAllDuties();

                Duty dutyToBeDelete = allDuties.Find(d=> d.Name == testDutyName);


                Assert.That(DutyExists(dutyToBeDelete.Name), Is.True);

                _dutyOverviewPageBase.removeDutyFromDB(dutyToBeDelete);

                Assert.That(DutyExists(dutyToBeDelete.Name), Is.False);
            }
        }
    }
}