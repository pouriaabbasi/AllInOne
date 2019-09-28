using System;

namespace AllInOne.Models.Accounting.Plan
{
    public class EditPlanModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
    }
}