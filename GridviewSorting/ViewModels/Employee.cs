using System;
using System.Web;

namespace GridviewSorting.ViewModels
{
    public class Employee 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Location { get; set; }
        public DateTime OnboardDate { get; set; }
    }
}
