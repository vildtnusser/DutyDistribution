using DutyDistribution.Components.Pages;
using Moq;
using System.Collections.Generic;
using System.Transactions;
using DutyDistribution.Components.Interfaces;
using DutyDistribution.Components.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DutyDistributionTest
{
    public class PersonPageBaseTest
    {
        private static PersonPageBase _personPageBase;

        public static bool PersonExists(string personName)
        {
            var allPersons = Person.GetAllPersons();
            return (allPersons.Where(p => p.Name == personName).Count() > 0);

        }

        [SetUp]
        public void Setup()
        {
            var personPageBase = new PersonPageBase();
            _personPageBase = personPageBase;
        }

        [Test]
        public void AddPersonTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                //TODO Flush DB
                DataBase.OpenConnection();
                var newPersonName = "Person Test";
                Assert.That(PersonExists(newPersonName), Is.False);

                _personPageBase.addPersonToDB(newPersonName);

                Assert.That(PersonExists(newPersonName), Is.True);
            }
        }

        [Test]
        public void removePersonTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                //TODO Flush DB
                DataBase.OpenConnection();
                string testPersonName = "Person Test";
                _personPageBase.addPersonToDB(testPersonName);
                List<Person> allPersons = Person.GetAllPersons();

                Person personToBeDelete = allPersons.Find(p => p.Name == testPersonName);


                Assert.That(PersonExists(personToBeDelete.Name), Is.True);

                _personPageBase.removePersonFromDB(personToBeDelete);

                Assert.That(PersonExists(personToBeDelete.Name), Is.False);
            }
        }
    }
}