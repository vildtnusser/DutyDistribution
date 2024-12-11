using Microsoft.AspNetCore.Components;


namespace DutyDistribution.Components.Pages

{
    using System;
    using System.Collections.Generic;


    public class DutyOverviewPageBase : ComponentBase
    {
        public string nameTextField = "";
        
        public List<Duty> duties = Duty.getAllDuties();
        public void addDutyToDb(String nameTextField)
        {
            Duty.addDuty(nameTextField);
        }

        public void removeDutyFromDB(Duty dutyToBeDeleted)
        {
            Duty.removeDuty(dutyToBeDeleted.Id);
        }
    }

}