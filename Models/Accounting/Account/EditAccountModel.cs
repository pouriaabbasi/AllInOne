namespace AllInOne.Models.Accounting.Account
{
    public class EditAccountModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double InitialAmount { get; set; }
        public bool OveralTotal { get; set; }
        public bool IsDebit { get; set; }
        public bool IsCredit { get; set; }
    }
}