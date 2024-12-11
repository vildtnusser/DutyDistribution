using Microsoft.AspNetCore.Components;


namespace DutyDistribution.Components.Pages

{
    using System;
    using System.Collections.Generic;


    public class PersonPageBase : ComponentBase
    {
        public string nameTextField = "";
        
      
        public List<Person> persons = Person.getAllPersons();
        
        public void addPersonToDb(String nameTextField)
        {
            Person.addPerson(nameTextField);
        }
        
        public void removePersonFromDB(Person personToBeDeleted)
        {
            Person.removePerson(personToBeDeleted.Id);
        }
    }

}
