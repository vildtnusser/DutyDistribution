using DutyDistribution.Components.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;


namespace DutyDistribution.Components.Pages

{
    using System;
    using System.Collections.Generic;

    public class PersonPageBase: ComponentBase
    {
        public string nameTextField = "";
        public List<Person> persons = new();

        public PersonPageBase()
        {
            persons = Person.GetAllPersons();
        }

        public void addPersonToDB(String nameTextField)
        {
            Person.AddPerson(nameTextField);
        }
        
        public void removePersonFromDB(Person personToBeDeleted)
        {
            Person.RemovePerson(personToBeDeleted.Id);
        }
    }

}
