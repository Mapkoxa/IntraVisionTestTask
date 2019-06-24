using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntraVisionTestTask.Models
{
    public class CanAutomatViewModel
    {
        public List<CanOfDrinkViewModel> Drinks { get; set; }
        public int InsertMoney { get; set; }

        public List<CanOfDrinkViewModel> GainedDrinks { get; set; }
    }
}