using System;

namespace AllInOne.Models.Accounting.Plan
{
    public class AddPlanModel
    {
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public long UserId { get; set; }
    }
}