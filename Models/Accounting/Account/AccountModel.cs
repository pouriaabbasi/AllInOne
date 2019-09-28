namespace AllInOne.Models.Accounting.Account
{
    public class AccountModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long? ParentAccountId { get; set; }
        public string Name { get; set; }
        public double InitialAmount { get; set; }
        public bool OveralTotal { get; set; }
        public bool IsDebit { get; set; }
        public bool IsCredit { get; set; }
    }
}