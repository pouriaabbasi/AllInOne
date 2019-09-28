using System;

namespace AllInOne.Models.Accounting.Plan
{
    public class PlanModel
    {
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public long UserId { get; set; }
    }
}