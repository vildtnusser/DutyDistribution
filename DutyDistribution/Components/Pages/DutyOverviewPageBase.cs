using Microsoft.AspNetCore.Components;


namespace DutyDistribution.Components.Pages

{
    using System;
    using System.Collections.Generic;


    public class DutyOverviewPageBase : ComponentBase
    {
        public string nameTextField = "";
        
        public List<Duty> duties = Duty.GetAllDuties();
        public void addDutyToDB(String nameTextField)
        {
            Duty.AddDuty(nameTextField);
        }

        public void removeDutyFromDB(Duty dutyToBeDeleted)
        {
            Duty.RemoveDuty(dutyToBeDeleted.Id);
        }
    }

}