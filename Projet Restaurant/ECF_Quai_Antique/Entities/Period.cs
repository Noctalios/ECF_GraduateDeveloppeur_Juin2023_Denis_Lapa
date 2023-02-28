namespace ECF_Quai_Antique.Entities
{
    public class Period
    {
        public int Id { get; set; }

        public int Service { get; set; }

        public decimal Open { get; set; }

        public decimal Close { get; set; }

        public Period(int id, int service, decimal open, decimal close)
        {
            Id = id;
            Service = service;
            Open = open;
            Close = close;
        }
    }
}
