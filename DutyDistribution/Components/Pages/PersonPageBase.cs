using Microsoft.AspNetCore.Components;


namespace DutyDistribution.Components.Pages

{
    using System;
    using System.Collections.Generic;


    public class PersonPageBase : ComponentBase
    {
        public string nameTextField = "";
        
        public List<Person> persons = DutyDistribution.Components.Pages.Person.getAllPersons();
        
        public void addPersonToDb(String nameTextField)
        {
            DutyDistribution.Components.Pages.Person.addPerson(nameTextField);
        }

        public void removePersonFromDB(Person personToBeDeleted)
        {
            DutyDistribution.Components.Pages.Person.removePerson(personToBeDeleted.Id);
        }
    }

}
