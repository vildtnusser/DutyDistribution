using Microsoft.AspNetCore.Components;


namespace DutyDistribution.Components.Pages

{
    using System;
    using System.Collections.Generic;


    public class DutyOverviewPageBase : ComponentBase
    {
        public string nameTextField = "";
        
        public List<Duty> duties = DutyDistribution.Components.Pages.Duty.getAllDuties();
        public void addDutyToDb(String nameTextField)
        {
            DutyDistribution.Components.Pages.Duty.addDuty(nameTextField);
        }

        public void removeDutyFromDB(Duty dutyToBeDeleted)
        {
            DutyDistribution.Components.Pages.Duty.removeDuty(dutyToBeDeleted.Id);
        }
    }

}