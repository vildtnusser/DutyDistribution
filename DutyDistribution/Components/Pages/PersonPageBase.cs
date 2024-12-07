using Microsoft.AspNetCore.Components;

namespace DutyDistribution.Components.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class PersonPageBase:ComponentBase
    {
        public string nameTextFieldPerson = "";
    
        public List<string> persons = new();
    }
}